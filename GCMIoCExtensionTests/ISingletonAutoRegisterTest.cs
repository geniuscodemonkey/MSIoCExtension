using GCMIoCExtension;

namespace GCMIoCExtensionTests
{
    [AutoRegister(IoCScope.Singleton)]
    public interface ISingletonAutoRegisterTest
    {
    }

    public interface ISingletonAutoRegisterInheirtance
    {
    }

    [AutoRegister(IoCScope.Singleton)]
    public interface ISingletonAutoRegisterInheirtance2 : ISingletonAutoRegisterInheirtance
    {
    }
    
    public class SingletonAutoRegisterTest2 : ISingletonAutoRegisterInheirtance2
    {
    }
}