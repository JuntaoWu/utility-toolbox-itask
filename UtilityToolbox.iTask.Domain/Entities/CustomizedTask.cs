using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityToolbox.iTask.Domain.Entities
{
    public class CustomizedTask
    {
        public int ID { get; set; }
        public string Value { get; set; }

        public NormalizedTask NormalizedTask { get; set; }

        public ColumnDefinition ColumnDefinition { get; set; }

        public SystemInfo SystemInfo { get; set; }
    }
}
