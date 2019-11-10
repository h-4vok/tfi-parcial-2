using Guzmanflix.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.DAL
{
    public class StreamingChannelDAL : BaseDAL<StreamingChannel, int>
    {
        #region Multi thread safe singleton

        private StreamingChannelDAL()
        {
        }
        static StreamingChannelDAL() { }

        public static StreamingChannelDAL Instance { get; } = new StreamingChannelDAL();

        #endregion

        protected override Func<StreamingChannel, int> GetIdClosure => x => x.Code;
    }
}
