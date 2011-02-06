using System.Web.Mvc;
using CommandService;
using Microsoft.Practices.Unity;
using ReadService;
using Repositories.Storage;
using Web.Models.Infrastructure;

//[assembly: WebActivator.PreApplicationStartMethod(typeof(Web.AppStart_Unity), "Start")]

namespace Web
{
    public static class AppStart_Unity {
        public static void RegisterServices(IUnityContainer container) {
            container.RegisterType<IKanbanBoardRepository, KanbanBoardRepository>();
            container.RegisterType<IKanbanBoardReadService, KanbanBoardReadService>();
            container.RegisterType<IAuthenticationService, KanbanAuthenticationService>();
            container.RegisterType<IKanbanBoardCommandService, KanbanBoardCommandService>();

        }

        public static void Start() {
            // Create Unity container
            IUnityContainer container = new UnityContainer();

            // Register services with our Unity Container
            RegisterServices(container);

            // Tell ASP.NET MVC 3 to use our Unity DI Container 
            DependencyResolver.SetResolver(new UnityServiceLocator(container));
        }
    }
}