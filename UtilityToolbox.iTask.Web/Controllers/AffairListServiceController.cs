using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UtilityToolbox.iTask.Domain.Interface;
using System.Threading.Tasks;
using UtilityToolbox.iTask.Web.Models;

namespace UtilityToolbox.iTask.Web.Controllers
{
    public class AffairListServiceController : ApiController
    {
        private ITaskRepository repo;

        public AffairListServiceController(ITaskRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<AffairViewModel>> Get()
        {
            return await Task.Run<List<AffairViewModel>>(() =>
            {
                return repo.NormalizedTasks.Select(t => new AffairViewModel(t)).ToList();
            });
        }
    }
}
