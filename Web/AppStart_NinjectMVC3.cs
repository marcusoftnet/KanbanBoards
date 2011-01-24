using System.Web.Mvc;
using Ninject;
using Ninject.Mvc3;
using Web.Storage;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Web.AppStart_NinjectMVC3), "Start")]

namespace Web {
    public static class AppStart_NinjectMVC3 {
        public static void RegisterServices(IKernel kernel) {
            kernel.Bind<IKanbanBoardRepository>().To<KanbanBoardRepository>();
        }

        public static void Start() {
            // Create Ninject DI Kernel 
            IKernel kernel = new StandardKernel();

            // Register services with our Ninject DI Container
            RegisterServices(kernel);

            // Tell ASP.NET MVC 3 to use our Ninject DI Container 
            DependencyResolver.SetResolver(new NinjectServiceLocator(kernel));
        }
    }
}
