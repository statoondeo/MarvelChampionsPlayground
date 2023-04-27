public sealed class TreatStartComponent : ITreatStart
{
    public int TreatStart { get; private set; }
    private TreatStartComponent(int treatStart) => TreatStart = treatStart;
    public static ITreatStart Get(int treatStart) => new TreatStartComponent(treatStart);
}