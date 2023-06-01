public sealed class NoCardPicker : BasePicker<ICard>
{
    private NoCardPicker() : base() { }
    public static IPicker<ICard> Get() => new NoCardPicker();
}
