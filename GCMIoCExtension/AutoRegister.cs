using System;

namespace GCMIoCExtension
{
    public class AutoRegister : Attribute, IAutoRegister
    {
        public IoCScope Scope { get; }
        public AutoRegister(IoCScope scope)
        {
            Scope = scope;
        }
    }
}
