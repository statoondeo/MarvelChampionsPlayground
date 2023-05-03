using System.Collections.Generic;

public interface IFlipComponent : IComponent<IFlipComponent>
{
    ICoreFacade CurrentFace { get; }
    IDictionary<string, ICoreFacade> Faces { get; }
    void FlipTo(string face);
}
