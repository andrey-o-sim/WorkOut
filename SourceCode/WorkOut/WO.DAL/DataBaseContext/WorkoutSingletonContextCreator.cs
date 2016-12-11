using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.DAL.DataBaseContext
{
    public class WorkoutSingletonContextCreator
    {
        private static WorkOutContext _instanse;
        private WorkoutSingletonContextCreator() { }

        public static WorkOutContext Instanse
        {
            get
            {
                if (_instanse == null)
                {
                    _instanse = new WorkOutContext("WorkOutDbConnection");
                }

                return _instanse;
            }
        }
    }
}
