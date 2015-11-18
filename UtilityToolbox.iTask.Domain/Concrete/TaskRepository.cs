using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityToolbox.iTask.Domain.Entities;
using UtilityToolbox.iTask.Domain.Interface;

namespace UtilityToolbox.iTask.Domain.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        private TaskContext context = new TaskContext();

        public IEnumerable<NormalizedTask> NormalizedTasks
        {
            get
            {
                return context.NormalizedTasks;
            }
            set { }
        }

        public NormalizedTask GetNormalizedTask(int id)
        {
            return context.NormalizedTasks.FirstOrDefault(t => t.ID == id);
        }

        public void UpdateNormalizedTask(NormalizedTask task)
        {
            if (task.ID == 0)
            {
                context.NormalizedTasks.Add(task);
            }
            else
            {
                var existEntry = context.Entry<NormalizedTask>(task);
                existEntry.State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChangesAsync();
        }
    }
}
