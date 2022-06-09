using Autofac;
using CeSignia.Core.DI;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace CeSignia.Core;

public static class Startup<T> where T : IApplicationConfigurator, new()
{
    private static readonly ApplicationDependencyBuilder _applicationDependencyBuilder;
    private static readonly T _applicationStateBuilder;

    static Startup()
    {
        _applicationDependencyBuilder = new ApplicationDependencyBuilder();
        _applicationStateBuilder = new T();
    }

    public static void Run()
    {
        var window = Window.Create(WindowOptions.Default);
        window.Load += () =>
        {
            _applicationDependencyBuilder.RegisterInstance(window);
            _applicationDependencyBuilder.RegisterInstance(window.CreateOpenGL());
            _applicationDependencyBuilder.RegisterInstance(window.CreateInput());

            _applicationDependencyBuilder.RegisterType<RenderController>(DependencyScope.Singleton);

            _applicationStateBuilder.RegisterDependencies(_applicationDependencyBuilder);

            var context = _applicationDependencyBuilder.Build();

            foreach (var dependency in context.Resolve<IEnumerable<IHookApplicationLoading>>())
            {
                dependency.OnApplicationLoading();
            }
        };

        window.Run();
    }
}