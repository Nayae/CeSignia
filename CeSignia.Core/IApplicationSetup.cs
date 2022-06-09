using CeSignia.Core.DI;

namespace CeSignia.Core;

public interface IApplicationSetup
{
    void Setup(ApplicationBuilder builder);
}