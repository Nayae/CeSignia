using CeSignia.Core;
using CeSignia.Core.DI;
using ImGuiNET;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.Windowing;

namespace CeSignia.Engine.UserInterface;

public class ImGuiRenderComponent : IRenderComponent, IHookApplicationLoading, IHookDependencyRelease
{
    public const string ImGuiSaveLocation = "Resources/Settings/imgui.ini";

    public int RenderOrder => 0;

    private readonly GL _gl;
    private readonly IWindow _window;
    private readonly IInputContext _inputContext;

    private ImGuiController _controller;

    public ImGuiRenderComponent(GL gl, IWindow window, IInputContext inputContext)
    {
        _gl = gl;
        _window = window;
        _inputContext = inputContext;
    }

    public void OnApplicationLoading()
    {
        _controller = new ImGuiController(_gl, _window, _inputContext, () =>
        {
            var io = ImGui.GetIO();
            io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            io.WantSaveIniSettings = false;

            ImGui.LoadIniSettingsFromDisk(ImGuiSaveLocation);
        });
    }

    public void Render(float delta)
    {
        _controller.Update(delta);

        ImGui.DockSpaceOverViewport(null, ImGuiDockNodeFlags.PassthruCentralNode);
        ImGui.ShowDemoWindow();
        ImGui.ShowStackToolWindow();

        _controller.Render();
    }

    public void OnDependencyRelease()
    {
        ImGui.SaveIniSettingsToDisk(ImGuiSaveLocation);
        _controller.Dispose();
    }
}