using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityToolbox.iTask.Domain.Entities
{
    public class Label
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        //Navigator
        public virtual MileStone MileStone { get; set; }
        public virtual List<NormalizedTask> NormalizedTasks { get; set; }
    }
}
