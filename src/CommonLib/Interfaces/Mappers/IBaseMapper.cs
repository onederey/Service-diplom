using CommonLib.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Interfaces.Mappers
{
    public interface IBaseMapper
    {
        IDataEntity Map(ICollection<string> rows);
    }
}
