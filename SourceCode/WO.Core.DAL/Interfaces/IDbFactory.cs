using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.DAL.DataBaseContext;

namespace WO.Core.DAL.Interfaces
{
    public interface IDbFactory
    {
        WorkOutContext Init();
    }
}
