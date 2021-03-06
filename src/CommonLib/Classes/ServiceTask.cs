using CommonLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Classes
{
    public class ServiceTask : IServiceTask
	{
		public int TaskID { get; set; }
		public int TaskType { get; set; }
		public int? Branch { get; set; }
		public string? TaskName { get; set; }
		public string Dependency { get; set; } = string.Empty;
		public DateTime? LastWorkTime { get; set; }
		public DateTime? TaskStartTime { get; set; }
		public DateTime? TaskEndTime { get; set; }
		public string FilePath { get; set; } = string.Empty;
		public int? FieldsCount { get; set; }
		public string FieldsSeparator { get; set; } = "#";
	}
}
