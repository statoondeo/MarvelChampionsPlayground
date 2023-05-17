using System.Collections.Generic;

public interface IFlipComponent : IComponent<IFlipComponent>
{
    IFace CurrentFace { get; }
    IList<IFace> Faces { get; }
    void FlipTo(int faceIndex);
    void FlipToNext();
    bool IsFace(int faceIndex);
}
