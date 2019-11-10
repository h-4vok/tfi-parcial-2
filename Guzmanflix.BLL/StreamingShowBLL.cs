using Guzmanflix.BE;
using Guzmanflix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.BLL
{
    public class StreamingShowBLL : BaseBLL<StreamingShow, int>
    {
        public StreamingShowBLL() : base(StreamingShowDAL.Instance) { }
    }
}
