using CommonLib.Classes;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace Data.ImportExportService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IOptions<TaskSettings> _options;

        public Worker(ILogger<Worker> logger, IOptions<TaskSettings> options)
        {
            _logger = logger;
            _options = options;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(_options.Value.TaskDelay, stoppingToken);
            }
        }
    }
}