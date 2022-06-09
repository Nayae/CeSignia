namespace CeSignia.Core.Rendering;

public interface IRenderComponent
{
    public int Order { get; }

    void Render(float delta);
}