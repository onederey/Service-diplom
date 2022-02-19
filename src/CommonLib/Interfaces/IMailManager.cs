using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Interfaces
{
    public interface IMailManager
    {
        void SendWarning();
        void SendError();
    }
}
