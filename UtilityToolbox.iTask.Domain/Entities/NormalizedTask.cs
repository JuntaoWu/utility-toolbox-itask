using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityToolbox.iTask.Domain.Entities
{
    public class NormalizedTask
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SystemInfo SystemInfo { get; set; }
        public DateTime? ExpectedTime { get; set; }

        //Navigator
        public virtual List<CustomizedTask> CustomizedTasks { get; set; }
        public virtual List<MileStone> MileStones { get; set; }
        public virtual List<Label> Labels { get; set; }
    }
}
