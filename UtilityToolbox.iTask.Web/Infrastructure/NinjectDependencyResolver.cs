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
using System.Web.Http.Dependencies;

namespace UtilityToolbox.iTask.Web.Infrastructure
{
    public class NinjectDependencyScope : IDependencyScope
    {
        protected IResolutionRoot resolver;

        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        public void Dispose()
        {
            var disposible = resolver as IDisposable;
            if(disposible != null)
            {
                disposible.Dispose();
            }
            resolver = null;
        }

        public object GetService(Type serviceType)
        {
            return resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return resolver.GetAll(serviceType);
        }
    }

    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver
    {
        public IKernel Kernel { get { return this.resolver as IKernel; } }

        public NinjectDependencyResolver() : this(new StandardKernel()) { }

        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.AddBindings();
        }
        
        private IBindingToSyntax<T> Bind<T>()
        {
            return Kernel.Bind<T>();
        }

        private void AddBindings()
        {
            Mock<ITaskRepository> mock = new Mock<ITaskRepository>();
            mock.Setup(i => i.NormalizedTasks).Returns(
                new List<NormalizedTask> { }
            );
            mock.Setup(i => i.GetNormalizedTask(It.IsAny<int>())).Returns(
                new NormalizedTask { ID = 1, ExpectedTime = DateTime.Now }    
            );
            Bind<ITaskRepository>().ToConstant(mock.Object);
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(Kernel.BeginBlock());
        }
    }
}
