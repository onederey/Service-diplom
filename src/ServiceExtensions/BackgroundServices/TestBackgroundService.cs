using CommonLib.Classes;
using CommonLib.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ServiceExtensions.BackgroundServices
{
    public class TestBackgroundService : BaseBackgroundService<TestBackgroundService>
    {
        public override string BackgroundServiceName { get; set; } = "TestTask1";
        public override ServiceTask ServiceTaskWork { get; set; }
        public override int Branch { get; set; } = 0;

        public TestBackgroundService(ILogger<TestBackgroundService> logger, IOptions<TaskSettings> options, ITaskDataManager taskDataManager, IMailManager mailManager) : base(logger, options, taskDataManager, mailManager)
        {
        }

        protected override void ExecuteAsyncInternal()
        {
            //implement
        }
    }
}
