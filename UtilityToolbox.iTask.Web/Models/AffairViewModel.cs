using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityToolbox.iTask.Domain.Entities;

namespace UtilityToolbox.iTask.Web.Models
{
    public class AffairViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ExpectedTime { get; set; }

        public AffairViewModel() { }

        public AffairViewModel(NormalizedTask task)
        {
            if (task == null)
            {
                return;
            }

            ID = task.ID;
            Title = task.Title;
            Description = task.Description;
            //ExpectedTime = task.ExpectedTime?.ToUniversalTime();

            if (task.ExpectedTime.HasValue)
            {
                ExpectedTime = DateTime.SpecifyKind(task.ExpectedTime.Value, DateTimeKind.Utc);
            }
        }
    }

    public static class AffairViewModelExtension
    {
        public static NormalizedTask ToNormalizedTask(this AffairViewModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new NormalizedTask
            {
                ID = model.ID,
                Title = model.Title,
                Description = model.Description,
                ExpectedTime = model.ExpectedTime
            };

        }
    }
}
