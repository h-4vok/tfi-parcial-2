using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.BE
{
    public class SilverServicePlan : ServicePlan
    {
        public override int ClientPurchaseDiscount
        {
            get
            {
                return 15;
            }
        }
    }
}
