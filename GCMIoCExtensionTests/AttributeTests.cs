using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCMIoCExtension;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace GCMIoCExtensionTests
{
    [TestClass]
    public class AttributeTests
    {
        [TestMethod]
        public void DiscoverInterfaceWithAttribute()
        {
            // Assign
            IServiceCollection ioc = new ServiceCollection();

            // Act
            ioc.AddAutoRegister();
            var provider = ioc.BuildServiceProvider();

            // Assert
            // Singleton Check
            var a = provider.GetService<ISingletonAutoRegisterTest>();
            a.ShouldNotBeNull();
            var b = provider.GetService<ISingletonAutoRegisterTest>();
            a.ShouldBeSameAs(b);

            // Transient Check
            var x = provider.GetService<ITransientAutoRegisterTest>();
            x.ShouldNotBeNull();
            var y = provider.GetService<ITransientAutoRegisterTest>();
            x.ShouldNotBeSameAs(y);
        }


    }
    public class SingletonAutoRegisterTest : ISingletonAutoRegisterTest
    {

    }
    public class TransientAutoRegisterTest : ITransientAutoRegisterTest
    {

    }
}
