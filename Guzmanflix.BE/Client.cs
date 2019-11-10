using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.BE
{
    public class Client
    {
        public int Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
        public IList<ServicePlan> ServicePlans { get; set; } = new List<ServicePlan>();
        public double FinalFee {
            get
            {
                double final = 0;
                double maxDiscount = 0;
                foreach(var plan in this.ServicePlans)
                {
                    final += plan.Price;
                    if (plan.ClientPurchaseDiscount > maxDiscount)
                    {
                        maxDiscount = plan.ClientPurchaseDiscount;
                    }
                }

                final = final - (final * (maxDiscount / 100));
                return final;
            }
        }

        public int SilverPlansCount
        {
            get
            {
                return this.ServicePlans.Count(x => x is SilverServicePlan);
            }
        }

        public int PremiumPlansCount
        {
            get
            {
                return this.ServicePlans.Count(x => x is PremiumServicePlan);
            }
        }
    }
}
