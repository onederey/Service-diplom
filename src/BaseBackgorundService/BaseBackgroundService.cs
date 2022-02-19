using BaseBackgorundService.Interfaces;
using CommonLib.Interfaces;
using Data.ImportExportService;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BaseBackgorundService
{
    public abstract class BaseBackgroundService : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IOptions<TaskSettings> _options;
        private readonly ITaskDataManager _taskDataManager;
        private readonly IMailManager _mailManager;

        protected BaseBackgroundService(
            ILogger<Worker> logger,
            IOptions<TaskSettings> options,
            ITaskDataManager taskDataManager,
            IMailManager mailManager)
        {
            _logger = logger;
            _options = options;
            _taskDataManager = taskDataManager;
            _mailManager = mailManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Base running at: {time}", DateTimeOffset.Now);

                //try
                //{
                //    GetActualTask();
                //    if (NeedToExecute())
                //        ExecuteAsyncInternal();
                //}
                //catch (Exception ex)
                //{
                //    _logger.LogCritical(ex.Message);
                //}

                await Task.Delay(_options.Value.TaskDelay, stoppingToken);
            }

            throw new NotImplementedException();
        }

        protected void GetActualTask()
        {
            throw new NotImplementedException();
        }

        protected bool NeedToExecute()
        {
            throw new NotImplementedException();
        }

        protected void ExecuteAsyncInternal()
        {
            throw new NotImplementedException();
        }
    }
}