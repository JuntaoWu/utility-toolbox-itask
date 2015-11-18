using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityToolbox.iTask.Domain.Entities
{
    public class AdvancedTaskInfo
    {
        public int ID { get; set; }

        //Navigator
        public virtual NormalizedTask NormalizedTask { get; set; }
    }
}
