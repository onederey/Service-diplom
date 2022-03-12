using CommonLib.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Interfaces
{
    public interface IFileParser
    {
        ParsingResult Parse(string filePath);
    }
}
