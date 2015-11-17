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
    public class AffairController : ApiController
    {
        private ITaskRepository repo;

        public AffairController(ITaskRepository repo)
        {
            this.repo = repo;
        }

        public async Task<AffairViewModel> Get(int id)
        {
            return await Task.Run<AffairViewModel>(() =>
            {
                NormalizedTask task = repo.GetNormalizedTask(id);
                return new AffairViewModel { ID = 1, ExpectedTime = DateTime.Now };
            });
        }
    }
}
