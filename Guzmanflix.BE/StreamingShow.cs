using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.BE
{
    public class StreamingShow
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int QuantityOfSeasons { get; set; }
        public int Ranking { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
    }
}
