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
            if (disposible != null)
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

    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        //private static Lazy<IKernel> lazy = new Lazy<IKernel>(() =>
        //{
        //    return new StandardKernel();
        //});

        public IKernel Kernel { get { return this.resolver as IKernel; } }

        public NinjectDependencyResolver() : this(new StandardKernel()) { }

        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            Resolve();
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(Kernel.BeginBlock());
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return Kernel.Bind<T>();
        }

        public virtual void Resolve()
        {
            
        }
    }
}
