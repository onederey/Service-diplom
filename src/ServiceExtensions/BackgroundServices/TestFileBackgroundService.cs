using CommonLib.Classes;
using CommonLib.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceExtensions.BackgroundServices
{
    public class TestFileBackgroundService : BaseFileImportBackgroundService
    {
        public override string BackgroundServiceName { get; set; } = "TestFileHAHAHAHAHHAHAHA";
        public override ServiceTask ServiceTaskWork { get; set; }
        public override int Branch { get; set; } = 0;

        public TestFileBackgroundService(ILogger<BaseFileImportBackgroundService> logger, IOptions<TaskSettings> options, ITaskDataManager taskDataManager, IMailManager mailManager, IFileParser fileParser) : base(logger, options, taskDataManager, mailManager, fileParser)
        {
        }

        protected override void ExecuteAsyncInternal()
        {
            throw new NotImplementedException();
        }
    }
}
