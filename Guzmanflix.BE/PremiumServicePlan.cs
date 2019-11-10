using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.BE
{
    public class PremiumServicePlan : ServicePlan
    {
        public override int ClientPurchaseDiscount { get { return 20; } }
    }
}
