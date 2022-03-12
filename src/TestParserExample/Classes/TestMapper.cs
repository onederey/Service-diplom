using CommonLib.Interfaces.Entity;
using CommonLib.Interfaces.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParserExample.Classes
{
    public class TestMapper : IBaseMapper
    {
        public IDataEntity Map(ICollection<string> rows)
        {
            throw new NotImplementedException();
        }
    }
}
