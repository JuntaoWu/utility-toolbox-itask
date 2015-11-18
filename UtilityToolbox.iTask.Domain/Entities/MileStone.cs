using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityToolbox.iTask.Domain.Entities
{
    public class MileStone
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //Navigator
        public virtual List<Label> Labels { get; set; }
        public virtual List<NormalizedTask> NormalizedTasks { get; set; }
    }
}
