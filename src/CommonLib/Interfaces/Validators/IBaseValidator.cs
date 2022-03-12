using CommonLib.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Interfaces.Validators
{
    public interface IBaseValidator
    {
        bool IsValid(IDataEntity dataEntity);
    }
}
