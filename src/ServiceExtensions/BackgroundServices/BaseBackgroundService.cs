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
        public abstract string Branch { get; set; }

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
                _logger.LogInformation($"       {BackgroundServiceName}");
                var tasks = _taskDataManager.GetAllTasks();
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
            //var task = SqlHelper.ExecuteQuery
        }

        protected bool NeedToExecute()
        {
            throw new NotImplementedException();
        }

        protected void ExecuteAsyncInternal()
        {
            throw new NotImplementedException();
        }

        private void InitConnString(string connectionString)
        {
            SqlHelper.ConnString = connectionString;
        }
    }
}
