using CeSignia.Core;
using CeSignia.Core.DI;
using CeSignia.Engine.UserInterface;

namespace CeSignia.Engine;

public class EngineConfigurator : IApplicationConfigurator
{
    public void RegisterDependencies(ApplicationDependencyBuilder builder)
    {
        SetActiveWorkingDirectory();

        builder.RegisterAs<IRenderComponent, ImGuiRenderComponent>(DependencyScope.Singleton);
    }

    private void SetActiveWorkingDirectory()
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (directory != null && !directory.GetFiles("CeSignia.csproj").Any())
        {
            directory = directory.Parent;
        }

        if (directory == null)
        {
            throw new Exception();
        }

        Directory.SetCurrentDirectory(directory.ToString());
    }
}