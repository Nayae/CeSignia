using CeSignia.Core;
using CeSignia.Engine;

namespace CeSignia;

internal class Program
{
    // public const string ImGuiSave = "Settings/imgui.ini";

    private static void Main()
    {
#if DEBUG
        Startup<EngineModule>.Run();
#elif RELEASE
        Console.WriteLine("No startup configured for RELEASE");
#endif

        // // Create a Silk.NET window as usual
        // _window = Window.Create(WindowOptions.Default);
        //
        // // Our loading function
        // _window.Load += () =>
        // {
        //     _controller = new ImGuiController(
        //         _gl = _window.CreateOpenGL(), // load OpenGL
        //         _window, // pass in our window
        //         _input = _window.CreateInput(), // create an input context
        //         () =>
        //         {
        //             var io = ImGui.GetIO();
        //             io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        //             io.WantSaveIniSettings = false;
        //         }
        //     );
        //
        //     ImGui.LoadIniSettingsFromDisk(ImGuiSave);
        //
        //     _framebuffer = _gl.GenFramebuffer();
        //     _gl.BindFramebuffer(FramebufferTarget.Framebuffer, _framebuffer);
        //
        //     _renderTexture = _gl.GenTexture();
        //     _gl.BindTexture(TextureTarget.Texture2D, _renderTexture);
        //
        //     _gl.TexImage2D(
        //         TextureTarget.Texture2D, 0, InternalFormat.Rgb, 100, 100,
        //         0, PixelFormat.Rgb, PixelType.UnsignedByte, null
        //     );
        //
        //     _gl.TexParameterI(
        //         TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear
        //     );
        //
        //     _gl.TexParameterI(
        //         TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear
        //     );
        //
        //     _gl.BindTexture(TextureTarget.Texture2D, 0);
        //
        //     _gl.FramebufferTexture2D(
        //         FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0,
        //         TextureTarget.Texture2D, _renderTexture, 0
        //     );
        //
        //     _gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        // };
        //
        // // Handle resizes
        // _window.FramebufferResize += s =>
        // {
        //     // Adjust the viewport to the new window size
        //     _gl.Viewport(s);
        // };
        //
        // // The render function
        // _window.Render += delta =>
        // {
        //     // Make sure ImGui is up-to-date
        //     _controller.Update((float)delta);
        //
        //     _gl.BindFramebuffer(FramebufferTarget.Framebuffer, _framebuffer);
        //     _gl.ClearColor(Color.Red);
        //     _gl.Clear((uint)ClearBufferMask.ColorBufferBit);
        //     _gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        //
        //     // This is where you'll do any rendering beneath the ImGui context
        //     // Here, we just have a blank screen.
        //     _gl.ClearColor(Color.White);
        //     _gl.Clear((uint)ClearBufferMask.ColorBufferBit);
        //
        //     // This is where you'll do all of your ImGUi rendering
        //     // Here, we're just showing the ImGui built-in demo window.
        //     ImGui.DockSpaceOverViewport(null, ImGuiDockNodeFlags.PassthruCentralNode);
        //     ImGui.ShowDemoWindow();
        //     ImGui.ShowStackToolWindow();
        //
        //     ImGui.Begin("Scene", ImGuiWindowFlags.Modal);
        //     ImGui.Image((IntPtr)_renderTexture, new Vector2(100, 100));
        //     ImGui.End();
        //
        //     // Make sure ImGui renders too!
        //     _controller.Render();
        // };
        //
        // // The closing function
        // _window.Closing += () =>
        // {
        //     // Dispose our controller first
        //     _controller.Dispose();
        //     ImGui.SaveIniSettingsToDisk(ImGuiSave);
        //
        //     // Dispose the input context
        //     _input.Dispose();
        //
        //     // Unload OpenGL
        //     _gl.Dispose();
        // };
        //
        // // Now that everything's defined, let's run this bad boy!
        // _window.Run();
    }
}