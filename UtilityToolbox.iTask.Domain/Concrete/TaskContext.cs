using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityToolbox.iTask.Common;
using UtilityToolbox.iTask.Domain.Entities;

namespace UtilityToolbox.iTask.Domain.Concrete
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base(nameOrConnectionString: Contants.ConnectionStringName) { }

        public DbSet<NormalizedTask> NormalizedTasks { get; set; }
        
    }
}
