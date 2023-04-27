using System;

public interface IFlip
{
    IFacade CurrentFace { get; }
    IRepository<string, IFacade> Faces { get; }
    Action<string> OnFlipped { get; set; }
    void FlipTo(string face);
}
