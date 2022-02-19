using CommonLib.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Interfaces
{
    public interface ITaskDataManager
    {
        ICollection<ServiceTask> GetAllTasks();
    }
}
