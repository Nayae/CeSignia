using Autofac;
using CeSignia.Core.DI;
using CeSignia.Core.Rendering;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace CeSignia.Core;

public static class Startup<T> where T : IApplicationSetup, new()
{
    private static readonly ApplicationBuilder _applicationBuilder;
    private static readonly T _applicationConfigurator;

    static Startup()
    {
        _applicationBuilder = new ApplicationBuilder();
        _applicationConfigurator = new T();
    }

    public static void Run()
    {
        var window = Window.Create(WindowOptions.Default);
        window.Load += () =>
        {
            _applicationBuilder.RegisterInstance(window);
            _applicationBuilder.RegisterInstance(window.CreateOpenGL());
            _applicationBuilder.RegisterInstance(window.CreateInput());

            _applicationBuilder.RegisterType<RenderHub>(DependencyScope.Singleton);

            _applicationConfigurator.Setup(_applicationBuilder);

            var context = _applicationBuilder.Build();
            foreach (var component in context.Resolve<IEnumerable<IHookApplicationLoading>>())
            {
                component.OnApplicationLoading();
            }
        };

        window.Run();
    }
}