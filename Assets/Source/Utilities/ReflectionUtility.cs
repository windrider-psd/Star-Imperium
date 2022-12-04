using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Utilities
{
    public static class ReflectionUtility
    {
        public static void ExecuteMethodsWithAttribute<T>(object instance) where T: Attribute
        {
            var methods = AppDomain.CurrentDomain.GetAssemblies() // Returns all currenlty loaded assemblies
            .SelectMany(x => x.GetTypes()) // returns all types defined in this assemblies
            .Where(x => x.IsClass) // only yields classes
            .SelectMany(x => x.GetMethods()) // returns all methods defined in those classes
            .Where(x => x.GetCustomAttributes(typeof(T), false).FirstOrDefault() != null); // returns only methods that have the T attribute

            
                foreach (var method in methods) // iterate through all found methods
                {
                    method.Invoke(instance, null); // invoke the method
                }
        }
    }
}
