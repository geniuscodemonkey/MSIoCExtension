using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace GCMIoCExtension
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddAutoRegister(this IServiceCollection serviceCollection)
        {
            IDictionary<Type, IoCScope> dict = GetInterfacesThatImplementAutoRegister();
            RegisterTypes(serviceCollection, dict);
            return serviceCollection;
        }

        private static void RegisterTypes(IServiceCollection serviceCollection, IDictionary<Type, IoCScope> dict)
        {
            foreach (var (type, t) in GetImplementationTypes(dict))
            {
                RegisterType(serviceCollection, type, t);
            }
        }

        private static IEnumerable<(Type type, KeyValuePair<Type, IoCScope> t)> GetImplementationTypes(IDictionary<Type, IoCScope> dict)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(assembly => assembly.GetTypes()
                                    .SelectMany(type => dict.Where(t => type != t.Key && !type.IsInterface && !type.IsAbstract && t.Key.IsAssignableFrom(type))
                                        .Select(t => (type, t))));
        }

        private static void RegisterType(IServiceCollection serviceCollection, Type type, KeyValuePair<Type, IoCScope> t)
        {
            switch (t.Value)
            {
                case IoCScope.Singleton:
                    {
                        serviceCollection.AddSingleton(t.Key, type);
                        break;
                    }
                case IoCScope.Transient:
                    {
                        serviceCollection.AddTransient(t.Key, type);
                        break;
                    }
            }
        }

        private static IDictionary<Type, IoCScope> GetInterfacesThatImplementAutoRegister()
        {
            IDictionary<Type, IoCScope> dict = new Dictionary<Type, IoCScope>();
            foreach (var t in GetAutoRegisterInterfaces())
            {
                RecordType(dict, t);
            }

            return dict;
        }

        private static IEnumerable<Type> GetAutoRegisterInterfaces()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                                            .SelectMany(assembly => assembly.GetTypes()
                                                .Where(t => t.IsInterface)
                                                .Where(t => t.GetCustomAttribute(typeof(AutoRegister)) != null));
        }

        private static void RecordType(IDictionary<Type, IoCScope> dict, Type t)
        {
            var att = t.GetCustomAttribute(typeof(AutoRegister)) as AutoRegister;
            dict.Add(t, att.Scope);
        }
    }
}