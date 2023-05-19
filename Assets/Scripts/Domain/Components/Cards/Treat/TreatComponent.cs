public sealed class TreatComponent : BaseCardComponent<ITreatComponent>, ITreatComponent
{
    private int _CurrentTreat;
    public int CurrentTreat
    {
        get => _CurrentTreat;
        private set
        {
            if (_CurrentTreat == value) return;
            _CurrentTreat = value;
            Card?.Raise<ITreatComponent>();
        }
    }
    private int InitialTreat;
    private TreatComponent(int treat) : base()
    {
        InitialTreat = treat;
        CurrentTreat = 0;
    }
    public void AddTreat(int treat) => CurrentTreat += treat;
    public void RemoveTreat(int treat) => CurrentTreat -= treat;
    public override void Init() => CurrentTreat = InitialTreat;

    public static ITreatComponent Get(int treat) => new TreatComponent(treat);
}
