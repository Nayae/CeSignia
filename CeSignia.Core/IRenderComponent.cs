namespace CeSignia.Core;

public interface IRenderComponent
{
    public int RenderOrder { get; }

    void Render(float delta);
}