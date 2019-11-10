using Guzmanflix.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.DAL
{
    public class ClientDAL : BaseDAL<Client, int>
    {
        #region Multi thread safe singleton

        private ClientDAL()
        {
            this.InitDefaultData();
        }
        static ClientDAL() { }

        public static ClientDAL Instance { get; } = new ClientDAL();

        #endregion

        private void InitDefaultData()
        {
            this.Create(new Client
            {
                Code = 1,
                FirstName = "John",
                LastName = "Cenna",
                BirthDate = new DateTime(1980, 12, 12),
                NationalId = "27456222"
            });

            this.Create(new Client
            {
                Code = 2,
                FirstName = "Roberto",
                LastName = "Lavagna",
                BirthDate = new DateTime(1950, 1, 2),
                NationalId = "1000000"
            });

            this.Create(new Client
            {
                Code = 3,
                FirstName = "Mirtha",
                LastName = "Legrand",
                BirthDate = new DateTime(1900, 1, 1),
                NationalId = "2"
            });
        }

        protected override Func<Client, int> GetIdClosure => x => x.Code;
    }
}
