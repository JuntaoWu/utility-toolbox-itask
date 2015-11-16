using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityToolbox.iTask.Domain.Entities;

namespace UtilityToolbox.iTask.Domain.Interface
{
    public interface ITaskRepository
    {
        IEnumerable<NormalizedTask> NormalizedTasks { get; set; }

        IEnumerable<NormalizedTask> GetNormalizedTask(int id);
    }
}
