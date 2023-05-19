using System.Collections.Generic;

public interface IFlipComponent : ICardComponent<IFlipComponent>
{
    ICardFace CurrentFace { get; }
    IList<ICardFace> Faces { get; }
    void FlipTo(int faceIndex);
    void FlipToNext();
    bool IsFace(int faceIndex);
}
