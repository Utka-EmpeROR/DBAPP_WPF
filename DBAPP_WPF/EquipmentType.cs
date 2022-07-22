using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAPP_WPF
{
    public class EquipmentType
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public int Id { get; set; }
        public EquipmentType(string name, string type, int id)
        {
            this.Name = name;
            this.TypeName = type;
            this.Id = id;
        }
        public override string ToString()
        {
            return $"{Name} {TypeName} {Id}";
        }
    }
}
