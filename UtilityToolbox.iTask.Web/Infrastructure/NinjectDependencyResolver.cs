using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Web.Mvc;
using UtilityToolbox.iTask.Domain.Interface;
using Moq;
using UtilityToolbox.iTask.Domain.Entities;
using Ninject.Syntax;

namespace UtilityToolbox.iTask.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public IKernel Kernel { get { return kernel; } }

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return kernel.Bind<T>();
        }

        private void AddBindings()
        {
            Mock<ITaskRepository> mock = new Mock<ITaskRepository>();
            mock.Setup(i => i.NormalizedTasks).Returns(
                new List<NormalizedTask> { }
            );
            Bind<ITaskRepository>().ToConstant(mock.Object);
        }
    }
}
