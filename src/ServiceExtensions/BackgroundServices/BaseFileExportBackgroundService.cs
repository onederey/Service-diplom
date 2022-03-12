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
    public class BaseFileExportBackgroundService : BaseBackgroundService<BaseFileExportBackgroundService>
    {
        public BaseFileExportBackgroundService(ILogger<BaseFileExportBackgroundService> logger, IOptions<TaskSettings> options, ITaskDataManager taskDataManager, IMailManager mailManager) : base(logger, options, taskDataManager, mailManager)
        {
        }

        public override string BackgroundServiceName { get; set; }
        public override ServiceTask ServiceTaskWork { get; set; }
        public override int Branch { get; set; }
    }
}
