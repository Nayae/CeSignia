using Autofac;
using Autofac.Builder;

namespace CeSignia.Core.DI;

public class ApplicationBuilder
{
    private readonly ContainerBuilder _builder;

    public ApplicationBuilder()
    {
        _builder = new ContainerBuilder();
    }

    public void RegisterAs<T, K>(DependencyScope scope) where T : notnull where K : T
    {
        var registration = _builder.RegisterType<K>();

        ProcessRegistration(registration, scope);

        registration.As<T>();
    }

    public void RegisterType<T>(DependencyScope scope)
    {
        ProcessRegistration(_builder.RegisterType<T>(), scope);
    }

    public void RegisterInstance<T>(T instance) where T : class
    {
        _builder.RegisterInstance(instance);
    }

    public void RegisterModule<T>() where T : IApplicationModule, new()
    {
        new T().Configure(this);
    }

    private void ProcessRegistration<T>(
        IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle> registration,
        DependencyScope scope
    )
    {
        if (typeof(IHookDependencyActivating).IsAssignableFrom(typeof(T)))
        {
            registration.OnActivating(args => { ((IHookDependencyActivating)args.Instance).OnDependencyActivating(); });
        }

        if (typeof(IHookDependencyActivated).IsAssignableFrom(typeof(T)))
        {
            registration.OnActivated(args => { ((IHookDependencyActivated)args.Instance).OnDependencyActivated(); });
        }

        if (typeof(IHookDependencyRelease).IsAssignableFrom(typeof(T)))
        {
            registration.OnRelease(instance => { ((IHookDependencyRelease)instance).OnDependencyRelease(); });
        }

        if (typeof(IHookApplicationLoading).IsAssignableFrom(typeof(T)))
        {
            registration.As<IHookApplicationLoading>();
        }

        switch (scope)
        {
            case DependencyScope.Singleton:
                registration.SingleInstance();
                break;
            case DependencyScope.Transient:
                registration.InstancePerDependency();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(scope), scope, null);
        }
    }

    internal IContainer Build()
    {
        return _builder.Build();
    }
}