using Guzmanflix.BE;
using Guzmanflix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.BLL
{
    public class StreamingChannelBLL : BaseBLL<StreamingChannel, int>
    {
        public StreamingChannelBLL() : base(StreamingChannelDAL.Instance) { }
    }
}
