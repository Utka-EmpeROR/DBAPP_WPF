using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAPP_WPF
{
    public class MatStock
    {
        public string Id { get; set; }
        public string NameRu { get; set; }
        public int Amount { get; set; }

        public MatStock(string id, string nameRu, int amount)
        {
            Id = id;
            NameRu = nameRu;
            Amount = amount;
        }
    }
}
