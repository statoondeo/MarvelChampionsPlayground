public sealed class TreatFacade : BaseFacade<ITreatComponent>, ITreatFacade
{
    public TreatFacade(ITreatComponent item) : base(item) { }
    public int CurrentTreat => Item.CurrentTreat;
    public void AddTreat(int treat) => Item.AddTreat(treat);
    public void RemoveTreat(int treat) => Item.RemoveTreat(treat);

    public static ITreatFacade Get() => new TreatFacade(TreatComponent.Get());
}