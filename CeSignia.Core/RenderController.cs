using System.Drawing;
using CeSignia.Core.DI;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace CeSignia.Core;

public class RenderController : IHookApplicationLoading
{
    private readonly GL _gl;
    private readonly IWindow _window;
    private readonly IRenderComponent[] _renderComponents;

    public RenderController(GL gl, IWindow window, IEnumerable<IRenderComponent> renderComponents)
    {
        _gl = gl;
        _window = window;
        _renderComponents = renderComponents.OrderBy(c => c.RenderOrder).ToArray();
    }

    public void OnApplicationLoading()
    {
        _window.Render += OnRender;
    }

    private void OnRender(double delta)
    {
        _gl.ClearColor(Color.White);
        _gl.Clear(ClearBufferMask.ColorBufferBit);

        foreach (var component in _renderComponents)
        {
            component.Render((float)delta);
        }
    }
}