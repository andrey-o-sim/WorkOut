using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.LoggerService;

namespace WO.LoggerFactory
{
    public interface ILoggerFactory
    {
        ILoggerService Create<T>() where T : class;
    }
}
