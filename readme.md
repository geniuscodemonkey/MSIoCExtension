# 1. GCM Microsoft IoC Extension

## 1.1. Overview

These project make up a class extension for the IServiceCollection Microsoft IoC contianer.

I got bored of continually adding Singletons or Transient classes to the IoC container; so I've created this handy class extension. All you need to do is add the _AutoRegister_ attribute to an interface specifying if it should be registered either as a Singleton or a Transient. Any class that then implements that interface will be registered with the IoC. 

**Example:**

``` csharp
IServiceCollection ioc = new ServiceCollection();
ioc.AddAutoRegister();
var provider = ioc.BuildServiceProvider();
var a = provider.GetService<ISingletonAutoRegisterTest>();

[AutoRegister(IoCScope.Singleton)]
public interface ISingletonAutoRegisterTest
{
}
```
