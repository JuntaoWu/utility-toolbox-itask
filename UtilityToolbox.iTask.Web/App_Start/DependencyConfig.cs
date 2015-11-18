using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using UtilityToolbox.iTask.Domain.Concrete;
using UtilityToolbox.iTask.Domain.Entities;
using UtilityToolbox.iTask.Domain.Interface;
using UtilityToolbox.iTask.Web.Infrastructure;

namespace UtilityToolbox.iTask.Web
{
    public sealed class DependencyConfig : NinjectDependencyResolver
    {
        public DependencyConfig() { }

        public DependencyConfig(IKernel kernel) : base(kernel) { }

        public override void Resolve()
        {
            Mock<ITaskRepository> mock = new Mock<ITaskRepository>();
            mock.Setup(i => i.NormalizedTasks).Returns(
                new List<NormalizedTask> { }
            );
            mock.Setup(i => i.GetNormalizedTask(It.IsAny<int>())).Returns(
                new NormalizedTask { ID = 1, ExpectedTime = DateTime.Now }
            );
            mock.Setup(i => i.UpdateNormalizedTask(It.IsAny<NormalizedTask>()));
            //Bind<ITaskRepository>().ToConstant(mock.Object);

            Bind<ITaskRepository>().To<TaskRepository>();
        }

        public static void RegisterDependencies(HttpConfiguration config)
        {
            DependencyConfig resolver = new DependencyConfig();
            config.DependencyResolver = resolver;  //For Web Api
            DependencyResolver.SetResolver(resolver);  //For Web Mvc
        }
    }
}
