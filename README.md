# NetDiExtension
Extension library for .NET Dependency Injection.

## Overview
This library extends the functionality of .NET Dependency Injection.

## Features
* Attribute-based DI registration.

## Installation
* Build the solution to make binary (dll file) and refer it from your project.

* (I'm planning to release a binary package via NuGet.)

## How to use
* Add a reference for NetDIExtension to your project.

### Register service using attribute
* To register your class to DI container, annotate your class with an appropriate attribute, then scan them while configuration phase.

``` cs
// In your service class file.
using NetDIExtension;

// Annotate with an appropriate attribute.
[TransientService]
// [ScopedService]
// [SingletonService]
// [Service(ServiceLifetime.Transient)]
public class MyService : IMyService { }
```

``` cs
// Initialize with ASP.NET Core Startup class...
public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
      NetDIExtension.ServiceManager.Scan(services);
      // To see debug info in your console, pass a flag.
      // NetDIExtension.ServiceManager.Scan(services, true);
      
      // You can get instances of registered services via constructor injection.
  }
}

// Initialize with .NET Core console app...
class Program
{
    static void Main(string[] args)
    {
        IServiceCollection service = new ServiceCollection();
        NetDIExtension.ServiceManager.Scan(services);
        IServiceProvider provider = services.BuildServiceProvider();

        // You can get instances of registered services from IServiceProvider.
        var myService = provider.GetService<IMyService>();
    }
}
```

* Attributes below can be used.

  * TransientService : A new instance of the services will be created every time it is requested.
  * ScopedService : A new instance of the service will be created for each scope.
  * SingletonService : A single instance of the service will be created.
  * Service : Generic style attribute. You need to specify the type of service with passing a parameter to the constructor. Above 3 attributes are short-hand and may be preferable.

* Configuring registration strategy.

  * "Service Type" and "Implementation Type" are registered to DI container.
    When you request an instance of specific type, the type is service type, and then DI container returns an implementation type instance.

  * Specifying attribute without any parameter, NetDIExtension finds service type automatically(*). In this case, an interface implemented by the class and named similar(**) to the class will be considered as a service Type.

    (*) Can be disable by passing false to the parameter "findService".

    (**) Naming convention for both C# and Java are acceptable.  
        <C#> Service: IMyService, Implementation: MyService
        <Java> Service: MyService, Implementation: MyServiceImpl

  * You can specify a service type explicitly by passing a type object of a service type.

  * If no candidate found, the class itself is considered as a service type. If multiple candidate found, NetDIExtension throws an exception.

``` cs
[TransientService]  // no parameter specified
public class MyService : IMyService { }
/*
  Candidate interface for the service type considered to having name that contains the class name (= MyService)
  In this case, IMyService matches the condition, so "Service Type: IMyService" and "Implementation Type: MyService" is registered to the DI container.
*/

[TransientService]  // no parameter specified
public class MyService : IDisposable { }
/*
  In this case, the class doesn't implement any interface that having similar name, so MyService will be considered as both "Service Type" and "Implementation Type".
*/

[TransientService(false)]  // set findService flag to false
public class MyService : IMyService { }
/*
  A parameter findService is set to false, so MyService will be considered as both "Service Type" and "Implementation Type".
*/

[TransientService]  // no parameter specified
public class MyService : IMyService1, IMyService2 { }
/*
  NetDIExtension can't determine which interface is to be "Service Type",
  so NetDIExtension will throw an exception.
*/

[TransientService(typeof(IMyService1))]  // set serviceType
public class MyService : IMyService1, IMyService2 { }
/*
  Service type is specified explicitly, so "Service Type: IMyService1" and "Implementation Type: MyService" is registered to the DI container.
*/
```

## Changelog
### May 5, 2020
* First release.
