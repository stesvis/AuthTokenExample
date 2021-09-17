using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace AuthTokenExample
{
    public static class UnityDependencyResolver
    {
        public static UnityContainer Resolve()
        {
            var unityContainer = new UnityContainer();
            return unityContainer;
        }
    }
}