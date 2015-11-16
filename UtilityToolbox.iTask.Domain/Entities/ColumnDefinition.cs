using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityToolbox.iTask.Domain.Entities
{
    public class ColumnDefinition
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SystemID { get; set; }
    }
}
