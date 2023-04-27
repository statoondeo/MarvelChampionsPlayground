using System;

public sealed class FlipComponent : IFlip
{
    public IRepository<string, IFacade> Faces { get; private set; }
    public IFacade CurrentFace { get; private set; }
    public Action<string> OnFlipped { get; set; }
    public FlipComponent(IFacade face, IFacade back)
    {
        Faces = new Repository<string, IFacade>();
        CurrentFace = Faces.Register("FACE", face);
        Faces.Register("BACK", back);
    }
    public void FlipTo(string face)
    {
        if (!Faces.TryGetValue(face, out IFacade newFace)) return;
        if (CurrentFace == newFace) return;
        CurrentFace = newFace;
        OnFlipped?.Invoke(face);
    }
}