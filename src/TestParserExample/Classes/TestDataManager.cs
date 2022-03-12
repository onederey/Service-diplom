using CommonLib.Interfaces.DataManagers;
using CommonLib.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParserExample.Classes
{
    public class TestDataManager : IBaseDataManager
    {
        public void ClearTemp()
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void Import(ICollection<IDataEntity> data)
        {
            throw new NotImplementedException();
        }
    }
}
