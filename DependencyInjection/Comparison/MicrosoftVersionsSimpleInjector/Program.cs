using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;

BenchmarkSwitcher.FromAssembly(typeof(SingletonBenchmarks).Assembly).Run(args);

[HideColumns("Error", "StdDev", "Median", "RatioSD")]
[MemoryDiagnoser]
public class SingletonBenchmarks
{
    private global::SimpleInjector.Container container;
    private global::Microsoft.Extensions.DependencyInjection.ServiceProvider serviceProvider;

    [GlobalSetup]
    public void Setup()
    {
        this.container = new();
        this.container.Register(typeof(IDependency<>), typeof(Dependency<>), global::SimpleInjector.Lifestyle.Singleton);
        this.container.Register<IInjected, Injected>(global::SimpleInjector.Lifestyle.Singleton);
        this.container.Verify();

        var serviceCollection = new global::Microsoft.Extensions.DependencyInjection.ServiceCollection();
        ((ICollection<global::Microsoft.Extensions.DependencyInjection.ServiceDescriptor>)serviceCollection).Add(new (typeof(IDependency<>), typeof(Dependency<>), global::Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton));
        ((ICollection<global::Microsoft.Extensions.DependencyInjection.ServiceDescriptor>)serviceCollection).Add(new (typeof(IInjected), typeof(Injected), global::Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton));
        this.serviceProvider = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(serviceCollection);
    }

    [Benchmark(Baseline = true)]
    public object? Microsoft() => this.serviceProvider.GetService(typeof(IInjected));

    [Benchmark]
    public object? SimpleInjector() => this.container.GetInstance(typeof(IInjected));
}

[HideColumns("Error", "StdDev", "Median", "RatioSD")]
[MemoryDiagnoser]
public class TransientBenchmarks
{
    private global::SimpleInjector.Container container;
    private global::Microsoft.Extensions.DependencyInjection.ServiceProvider serviceProvider;

    [GlobalSetup]
    public void Setup()
    {
        this.container = new();
        this.container.Register(typeof(IDependency<>), typeof(Dependency<>), global::SimpleInjector.Lifestyle.Transient);
        this.container.Register<IInjected, Injected>(global::SimpleInjector.Lifestyle.Transient);
        this.container.Verify();

        var serviceCollection = new global::Microsoft.Extensions.DependencyInjection.ServiceCollection();
        ((ICollection<global::Microsoft.Extensions.DependencyInjection.ServiceDescriptor>)serviceCollection).Add(new (typeof(IDependency<>), typeof(Dependency<>), global::Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient));
        ((ICollection<global::Microsoft.Extensions.DependencyInjection.ServiceDescriptor>)serviceCollection).Add(new (typeof(IInjected), typeof(Injected), global::Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient));
        this.serviceProvider = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(serviceCollection);
    }

    [Benchmark(Baseline = true)]
    public object? Microsoft() => this.serviceProvider.GetService(typeof(IInjected));

    [Benchmark]
    public object? SimpleInjector() => this.container.GetInstance(typeof(IInjected));
}

public interface IInjected { }

public class Injected : IInjected { public Injected(IDependency<Injected> dependency) { } }

public interface IDependency<T> { }

public class Dependency<T> : IDependency<T> { }
