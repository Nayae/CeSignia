using CeSignia.Core.DI;

namespace CeSignia.Core;

public interface IApplicationConfigurator
{
    void RegisterDependencies(ApplicationDependencyBuilder builder);
}