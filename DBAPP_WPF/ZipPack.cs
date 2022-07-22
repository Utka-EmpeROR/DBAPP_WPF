using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAPP_WPF
{
    public class ZipPack
    {
        public string Id;
        public List<MatStock> Components;

        public ZipPack(string Id, List<Material> mats, string matsIds, string matsAmounts)
        {
            try
            {
                Components = new List<MatStock>();
                this.Id = Id;
                string[] matsId = matsIds.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string[] matsAmount = matsAmounts.Split(';', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < matsAmount.Length; i++)
                {
                    Components.Add(new MatStock(matsId[i], mats.Find(material => material.article == matsId[i]).nameRu,
                        int.Parse(matsAmount[i])));
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Incorrect ZipPackData", "!!!");
                Id = "error";
            }
        }

        public void ConvertToStrings(out string matsIds, out string matsAmounts)
        {
            matsIds = "";
            matsAmounts = "";
            foreach (var item in Components)
            {
                matsIds += item.Id + ";";
                matsAmounts += item.Amount + ";";
            }
        }
    }
}
