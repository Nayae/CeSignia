using System.Drawing;
using CeSignia.Core.DI;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace CeSignia.Core.Rendering;

public class RenderHub : IHookApplicationLoading
{
    private readonly GL _gl;
    private readonly IWindow _window;
    private readonly IRenderController[] _controllers;

    public RenderHub(GL gl, IWindow window, IEnumerable<IRenderController> controllers)
    {
        _gl = gl;
        _window = window;
        _controllers = controllers.OrderBy(c => c.Order).ToArray();
    }

    public void OnApplicationLoading()
    {
        _window.Render += OnRender;
    }

    private void OnRender(double delta)
    {
        _gl.ClearColor(Color.White);
        _gl.Clear(ClearBufferMask.ColorBufferBit);

        foreach (var controller in _controllers)
        {
            controller.Render((float)delta);
        }
    }
}