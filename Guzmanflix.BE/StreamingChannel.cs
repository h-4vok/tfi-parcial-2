using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.BE
{
    public class StreamingChannel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public IList<StreamingShow> Shows { get; set; } = new List<StreamingShow>();
    }
}
