using CommonLib.Classes;
using CommonLib.Interfaces;
using CommonLib.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.DataManagers
{
    public class TaskDataManager : ITaskDataManager
    {
        public ICollection<ServiceTask> GetAllTasks()
        {
            return (ICollection<ServiceTask>)SqlHelper.ExecuteQuery<ServiceTask>("Service_GetAllTasks");
        }
    }
}
