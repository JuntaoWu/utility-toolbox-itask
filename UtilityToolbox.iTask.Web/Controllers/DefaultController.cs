using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityToolbox.iTask.Domain.Interface;

namespace UtilityToolbox.iTask.Web.Controllers
{
    public class DefaultController : Controller
    {
        private ITaskRepository repo;

        public DefaultController(ITaskRepository repository)
        {
            this.repo = repository;
        }

        // GET: Default
        public ActionResult Index()
        {
            
            return View();
        }
    }
}