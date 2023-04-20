public interface ITreatStart { int TreatStart { get; } }
public sealed class TreatStartComponent : ITreatStart
{
    public int TreatStart { get; private set; }
    public TreatStartComponent(int treatStart) => TreatStart = treatStart;
}