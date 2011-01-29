using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Web.Storage;

//[assembly: WebActivator.PreApplicationStartMethod(typeof(Web.AppStart_Unity), "Start")]

namespace Web
{
    public static class AppStart_Unity {
        public static void RegisterServices(IUnityContainer container) {
            container.RegisterType<IKanbanBoardRepository, KanbanBoardRepository>();
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