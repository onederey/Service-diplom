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
    public abstract class BaseFileImportBackgroundService : BaseBackgroundService<BaseFileImportBackgroundService>
    {
        private readonly IFileParser _fileParser;

        protected BaseFileImportBackgroundService(
            ILogger<BaseFileImportBackgroundService> logger,
            IOptions<TaskSettings> options,
            ITaskDataManager taskDataManager,
            IMailManager mailManager,
            IFileParser fileParser) : base(logger, options, taskDataManager, mailManager)
        {
            _fileParser = fileParser;
        }

        public override string BackgroundServiceName { get; set; }
        public override ServiceTask ServiceTaskWork { get; set; }
        public override int Branch { get; set; }
    }
}
