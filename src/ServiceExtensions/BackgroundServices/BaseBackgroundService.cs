using CommonLib.Classes;
using CommonLib.Interfaces;
using CommonLib.Sql;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ServiceExtensions.BackgroundServices
{
    public abstract class BaseBackgroundService<T> : BackgroundService
    {
        private readonly ILogger<T> _logger;
        private readonly IOptions<TaskSettings> _options;
        private readonly ITaskDataManager _taskDataManager;
        private readonly IMailManager _mailManager;

        public abstract string BackgroundServiceName { get; set; }
        public abstract ServiceTask ServiceTaskWork { get; set; }
        public abstract int Branch { get; set; }

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

        protected void GetActualTask()
        {
            var tasks = SqlHelper.ExecuteQuery<ServiceTask>("[dbo].[Service_GetAllTasks]");
            ServiceTaskWork = tasks.FirstOrDefault(task => task.TaskName == BackgroundServiceName && task.Branch == Branch);

            if(ServiceTaskWork == null)
            {
                throw new InvalidOperationException($"{BackgroundServiceName}. Cannot find task related to worker name.");
            }
        }

        /// <summary>
        /// Check dependencies, work time, last work time
        /// </summary>
        /// <returns></returns>
        protected bool NeedToExecute()
        {
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

        protected void ExecuteAsyncInternal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check field dependency of task.... TODO
        /// </summary>
        /// <returns></returns>
        private bool CheckDependencies()
        {

            return true;
        }

        private void InitConnString(string connectionString)
        {
            SqlHelper.ConnString = connectionString;
        }
    }
}
