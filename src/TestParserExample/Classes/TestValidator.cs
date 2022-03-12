using CommonLib.Interfaces.Entity;
using CommonLib.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParserExample.Classes
{
    public class TestValidator : IBaseValidator
    {
        public bool IsValid(IDataEntity dataEntity)
        {
            throw new NotImplementedException();
        }
    }
}
