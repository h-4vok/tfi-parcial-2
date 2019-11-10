using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.BE
{
    public abstract class ServicePlan
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public IList<StreamingChannel> Channels { get; set; } = new List<StreamingChannel>();
        public double Price { get; set; }
        public abstract int ClientPurchaseDiscount { get; }
    }
}
