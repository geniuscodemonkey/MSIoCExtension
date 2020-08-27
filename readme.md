# 1. GCM Microsoft IoC Extension

## 1.1. Overview

These project make up a class extension for the IServiceCollection Microsoft IoC contianer.

I got bored of continually adding Singletons or Transient classes to the IoC container; so I've created this handy class extension. All you need to do is add the _AutoRegister_ attribute to an interface specifying if it should be registered either as a Singleton or a Transient. Any class that then implements that interface will be registered with the IoC.

**Example:**

``` csharp
IServiceCollection ioc = new ServiceCollection();
ioc.AddAutoRegister();
var provider = ioc.BuildServiceProvider();
var a = provider.GetService<IMyService>();

[AutoRegister(IoCScope.Singleton)]
public interface IMyService
{
}
[AutoRegister(IoCScope.Transient)]
public interface IMyTransientObject
{
}
```

**N.B.**
You should only use this on the _Top Most_ interface within your inheirtance structure. This is so that you don't have parts of an inheirtance structure registered with the IoC.

If the _AutoRegister_ attribute is used within the inheirtance tree of the interfaces (i.e. a is assignable to b); then an _ArgumentException_ is thrown with the full name of both types so you can track down and fix the issue.
