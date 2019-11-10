using Guzmanflix.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.DAL
{
    public class StreamingShowDAL : BaseDAL<StreamingShow, int>
    {
        #region Multi thread safe singleton

        private StreamingShowDAL()
        {
            this.InitDefaultData();
        }
        static StreamingShowDAL() { }

        public static StreamingShowDAL Instance { get; } = new StreamingShowDAL();

        #endregion

        private void InitDefaultData()
        {
            this.Create(new StreamingShow()
            {
                Code = 1,
                Name = "La casa de retornos",
                Genre = "Cualquiera",
                QuantityOfSeasons = 12,
                Ranking = 1,
                Director = "George Washington"
            });

            this.Create(new StreamingShow()
            {
                Code = 2,
                Name = "Francella y el César contra los macacos",
                Genre = "Acción",
                QuantityOfSeasons = 3,
                Ranking = 2,
                Director = "Sebastián Noesvertzner"
            });

            this.Create(new StreamingShow()
            {
                Code = 3,
                Name = "Un argentino en el Nuevo Congo",
                Genre = "Drama",
                QuantityOfSeasons = 1,
                Ranking = 3,
                Director = "Dr. Ing. Prof. Titular Hugo Colombres"
            });

            this.Create(new StreamingShow()
            {
                Code = 4,
                Name = "Querida, encogí a los auditores de la ISO",
                Genre = "Comedia",
                QuantityOfSeasons = 123,
                Ranking = 4,
                Director = "He-man y She-hulk"
            });

            this.Create(new StreamingShow()
            {
                Code = 5,
                Name = "Érase una vez en Florencio Varela",
                Genre = "Terror",
                QuantityOfSeasons = 3,
                Ranking = 5,
                Director = "La comitiva del FMI"
            });

            this.Create(new StreamingShow()
            {
                Code = 6,
                Name = "Es la última vez que llamo al enano",
                Genre = "Dramón",
                QuantityOfSeasons = 2,
                Ranking = 6,
                Director = "Donald Trump"
            });
        }

        protected override Func<StreamingShow, int> GetIdClosure => x => x.Code;
    }
}
