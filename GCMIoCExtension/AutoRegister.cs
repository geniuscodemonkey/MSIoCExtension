using System;

namespace GCMIoCExtension
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public class AutoRegister : Attribute, IAutoRegister
    {
        public IoCScope Scope { get; }
        public AutoRegister(IoCScope scope)
        {
            Scope = scope;
        }
    }
}
