public sealed class TreatComponent : BaseComponent<ITreatComponent>, ITreatComponent
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
    private TreatComponent() : base()
    {
        Type = ComponentType.Treat;
        CurrentTreat = 0;
    }
    public void AddTreat(int treat) => CurrentTreat += treat;
    public void RemoveTreat(int treat) => CurrentTreat -= treat;
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        Card.AddListener<IResetComponent>(OnResetCallback);
    }
    private void OnResetCallback(IComponent component)
    {
        CurrentTreat = (Card.CurrentFace as ITreatStartComponent).TreatStart;
        Card.Tap();
    }

    public static ITreatComponent Get() => new TreatComponent();
}
