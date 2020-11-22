using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace SeliseTask_003
{
    public class UnityFactory
    {
        public static UnityContainer container;
        public static void RegisterComponents()
        {
            container = new UnityContainer();


            container.RegisterType<IDatetimeProvider, DatetimeProvider>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
