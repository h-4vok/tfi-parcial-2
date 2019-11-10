using Guzmanflix.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.DAL
{
    public class ServicePlanDAL : BaseDAL<ServicePlan, int>
    {
        #region Multi thread safe singleton

        private ServicePlanDAL()
        {
        }
        static ServicePlanDAL() { }

        public static ServicePlanDAL Instance { get; } = new ServicePlanDAL();

        #endregion

        protected override Func<ServicePlan, int> GetIdClosure => x => x.Code;
    }
}
