using CommonLib.Classes;
using CommonLib.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ServiceExtensions.BackgroundServices
{
    public class TestBackgroundService : BaseBackgroundService<TestBackgroundService>
    {
        public TestBackgroundService(ILogger<TestBackgroundService> logger, IOptions<TaskSettings> options, ITaskDataManager taskDataManager, IMailManager mailManager) : base(logger, options, taskDataManager, mailManager)
        {
        }
    }
}
