using CommonLib.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Interfaces.DataManagers
{
    public interface IBaseDataManager
    {
        void Import(ICollection<IDataEntity> data);

        int GetCount();

        void ClearTemp();
    }
}
