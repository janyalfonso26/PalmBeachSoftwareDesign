using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Infrastructure;
using DAL.Infrastructure.EF;
using Microsoft.Practices.Unity;

namespace BLL.Infrastructure
{
    public static class RegisterTypes
    {
        public static void RegisterBLLServiceTypes(string namespaceName, IUnityContainer container)
        {
            var list = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == namespaceName).ToList();

            var serviceInterfaces =
                   (from t in list
                    where
                        t.IsInterface
                    select new
                    {
                        i = t,
                        s = list.FirstOrDefault(x => t.IsAssignableFrom(x) &&
                                                           x.IsInterface == false)
                    }).ToList();

            foreach (var service in serviceInterfaces)
            {
                var currectInterfaceName = service.i.Name.Replace("Service", "Repository");
                var currentType = GetTypes._Gettypes("DAL.Infrastructure").FirstOrDefault(t => t.Name == currectInterfaceName);
                container.RegisterType(service.i, service.s, new InjectionConstructor(
                                                                new ResolvedParameter(currentType)));
            }
        }

        public static void RegisterDALRepositoryTypes(string namespaceName, IUnityContainer container)
        {
            var list = DAL.Infrastructure.EF.GetTypes._Gettypes(namespaceName);

            var serviceInterfaces =
                   (from t in list
                    where
                        t.IsInterface
                    select new
                    {
                        i = t,
                        s = list.FirstOrDefault(x => t.IsAssignableFrom(x) &&
                                                           x.IsInterface == false)
                    }).ToList();

            foreach (var service in serviceInterfaces)
            {
                if (!service.i.ToString().ToLower().Contains("unitofwork"))
                {
                    container.RegisterType(service.i, service.s);
                }
                container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            }
        }
    }
}
