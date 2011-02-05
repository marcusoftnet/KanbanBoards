using System.Web.Mvc;
using CommandService;
using Ninject;
using Ninject.Mvc3;
using ReadModel;
using Repositories.Storage;
using Web.Models.Infrastructure;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Web.AppStart_NinjectMVC3), "Start")]

namespace Web
{
    public static class AppStart_NinjectMVC3
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IKanbanBoardRepository>().To<KanbanBoardRepository>();
            kernel.Bind<IKanbanBoardReadService>().To<KanbanBoardReadService>();
            kernel.Bind<IAuthenticationService>().To<KanbanAuthenticationService>();
            kernel.Bind<IKanbanBoardCommandService>().To<KanbanBoardCommandService>();
        }

        public static void Start()
        {
            // Create Ninject DI Kernel 
            IKernel kernel = new StandardKernel();

            // Register services with our Ninject DI Container
            RegisterServices(kernel);

            // Tell ASP.NET MVC 3 to use our Ninject DI Container 
            DependencyResolver.SetResolver(new NinjectServiceLocator(kernel));
        }
    }
}
