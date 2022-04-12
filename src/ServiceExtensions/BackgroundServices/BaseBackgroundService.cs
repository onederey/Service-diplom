using CommonLib.Classes;
using CommonLib.Interfaces;
using CommonLib.Sql;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ServiceExtensions.BackgroundServices
{
    /// <summary>
    /// Base worker class for executing stored procedures and web services.
    /// Parent for file parsing and file creating.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseBackgroundService<T> : BackgroundService
    {
        private readonly ILogger<T> _logger;
        private readonly IOptions<TaskSettings> _options;
        private readonly ITaskDataManager _taskDataManager;
        private readonly IMailManager _mailManager;

        private ICollection<ServiceTask> _serviceTasks;

        public abstract string BackgroundServiceName { get; set; }
        public abstract ServiceTask ServiceTaskWork { get; set; }
        public abstract int Branch { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        protected BaseBackgroundService(
            ILogger<T> logger,
            IOptions<TaskSettings> options,
            ITaskDataManager taskDataManager,
            IMailManager mailManager)
        {
            _logger = logger;
            _options = options;
            _taskDataManager = taskDataManager;
            _mailManager = mailManager;

            InitConnString(_options.Value.ConnectionString);
        }

        /// <summary>
        /// Start working from here
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    GetActualTask();
                    if (NeedToExecute())
                        ExecuteAsyncInternal();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                }

                await Task.Delay(_options.Value.TaskDelay, stoppingToken);
            }
        }

        /// <summary>
        /// Get task for worker from list of all tasks
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        protected void GetActualTask()
        {
            _serviceTasks = (ICollection<ServiceTask>)SqlHelper.ExecuteQuery<ServiceTask>("[dbo].[Service_GetAllTasks]");
#pragma warning disable CS8601 // Possible null reference assignment.
            ServiceTaskWork = _serviceTasks?.FirstOrDefault(task => task.TaskName == BackgroundServiceName && task.Branch == Branch);
#pragma warning restore CS8601 // Possible null reference assignment.

            if (ServiceTaskWork == null)
                throw new InvalidOperationException($"{BackgroundServiceName}. Cannot find task related to worker name.");
        }

        /// <summary>
        /// Check dependencies, work time, last work time
        /// </summary>
        /// <returns></returns>
        protected bool NeedToExecute()
        {
            if (ServiceTaskWork.ManualStart)
                return true;

            if (ServiceTaskWork.IsEnabled)
            {
                if (ServiceTaskWork.LastWorkTime.HasValue && DateTime.Now.Date <= ServiceTaskWork.LastWorkTime.Value.Date)
                {
                    _logger.LogInformation($"{BackgroundServiceName}. Task already worked today.");
                    return false;
                }

                if (ServiceTaskWork.TaskStartTime.TimeOfDay > DateTime.Now.TimeOfDay 
                    || ServiceTaskWork.TaskEndTime.TimeOfDay < DateTime.Now.TimeOfDay)
                {
                    _logger.LogInformation($"{BackgroundServiceName}. Task is out from Start and End time settings.");
                    return false;
                }

                if(!CheckDependencies())
                {
                    _logger.LogInformation($"{BackgroundServiceName}. Task dependency is not resolved.");
                    return false;
                }
            }
            else
            {
                _logger.LogInformation($"{BackgroundServiceName}. Task is not enabled.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Main method for working
        /// </summary>
        protected virtual void ExecuteAsyncInternal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check field dependency of task
        /// </summary>
        /// <returns></returns>
        private bool CheckDependencies()
        {
            var dependencies = ServiceTaskWork.Dependency.Split(';');
            var dateTime = DateTime.Now;

            foreach(var dependency in dependencies)
            {
                var task = _serviceTasks.FirstOrDefault(task => task.TaskName == dependency);
                if (task != null && task.LastWorkTime.HasValue && task.LastWorkTime.Value.Date == dateTime.Date)
                    continue;
                else
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Initialize conn string inside
        /// </summary>
        /// <param name="connectionString"></param>
        private void InitConnString(string connectionString)
        {
            SqlHelper.ConnString = connectionString;
        }
    }
}
