using ChalangeYourself.Data.Model;
using ChalangeYourself.Services.Database;
using ChalangeYourself.Services.Repositories;
using ChalangeYourself.Website.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace ChalangeYourself.Website
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            RegisterRepositories(container);
            RegisterServicies(container);

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new InjectionConstructor());
            //container.RegisterType<DbContext, ChalangeDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
        private static void RegisterServicies(UnityContainer container)
        {

        }
        private static void RegisterRepositories(UnityContainer container)
        {
            container.RegisterType<UserRepository>();
            container.RegisterType<InterestRepository>();
            container.RegisterType<ChalangeRepository>();
        }
    }
}