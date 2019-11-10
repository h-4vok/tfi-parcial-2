using Guzmanflix.BE;
using Guzmanflix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.BLL
{
    public class ClientBLL : BaseBLL<Client, int>
    {
        public ClientBLL() : base(ClientDAL.Instance) { }
    }
}
