using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAPP_WPF
{
    public class Material
    {
        public string article { get; set; }
        public string nameRu { get; set; }
        public string nameEn { get; set; }
        public string country { get; set; }
        public string units { get; set; }
        public double cost { get; set; }
        public string matsType { get; set; }
        public int minNumber { get; set; }
        public string firm { get; set; }

        public Material(string article, string nameRu, string nameEn, string country,
            string units, double cost, string matsType, int minNumber, string firm)
        {
            this.article = article;
            this.nameRu = nameRu;
            this.nameEn = nameEn;
            this.country = country;
            this.units = units;
            this.cost = cost;
            this.matsType = matsType;
            this.minNumber = minNumber;
            this.firm = firm;
        }
    }
}
