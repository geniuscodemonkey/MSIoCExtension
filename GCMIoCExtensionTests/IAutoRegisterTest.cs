using GCMIoCExtension;

namespace GCMIoCExtensionTests
{
    [AutoRegister(IoCScope.Singleton)]
    public interface ISingletonAutoRegisterTest
    {
         
    }
    
    [AutoRegister(IoCScope.Transient)]
    public interface ITransientAutoRegisterTest
    {
         
    }
}