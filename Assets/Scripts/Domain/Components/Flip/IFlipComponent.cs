using System.Collections.Generic;

public interface IFlipComponent : IComponent<IFlipComponent>
{
    IFace CurrentFace { get; }
    IDictionary<string, IFace> Faces { get; }
    void FlipTo(string face);
    bool IsFace(string face);
}
