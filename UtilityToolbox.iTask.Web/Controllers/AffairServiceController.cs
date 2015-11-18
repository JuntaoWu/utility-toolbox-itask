using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UtilityToolbox.iTask.Domain.Entities;
using UtilityToolbox.iTask.Domain.Interface;
using UtilityToolbox.iTask.Web.Models;

namespace UtilityToolbox.iTask.Web.Controllers
{
    public class AffairServiceController : ApiController
    {
        private ITaskRepository repo;

        public AffairServiceController(ITaskRepository repo)
        {
            this.repo = repo;
        }

        public async Task<AffairViewModel> Get(int id)
        {
            return await Task.Run<AffairViewModel>(() =>
            {
                NormalizedTask task = repo.GetNormalizedTask(id);
                return new AffairViewModel(task);
            });
        }

        public async Task<AffairViewModel> Post(AffairViewModel model)
        {
            return await Task.Run<AffairViewModel>(() =>
            {
                NormalizedTask task = model.ToNormalizedTask();
                repo.UpdateNormalizedTask(task);
                model.ID = task.ID;
                return model;
            });
        }
    }
}
