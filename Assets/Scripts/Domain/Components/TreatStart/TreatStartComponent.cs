public sealed class TreatStartComponent : BaseComponent<ITreatStartComponent>, ITreatStartComponent
{
    public int TreatStart { get; private set; }
    private TreatStartComponent(int treatStart) : base()
    {
        Type = ComponentType.TreatStart;
        TreatStart = treatStart;
    }
    public static ITreatStartComponent Get(int treatStart) => new TreatStartComponent(treatStart);
}
