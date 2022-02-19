using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ImportExportService
{
    public  class TaskSettings
    {
        public const string Settings = "Settings";

        public string ConnectionString { get; set; } = string.Empty;
        public int TaskDelay { get; set; } = 1000;
    }
}
