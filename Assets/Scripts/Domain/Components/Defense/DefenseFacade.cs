public sealed class DefenseFacade : BaseFacade<IDefenseComponent>, IDefenseFacade
{
    private DefenseFacade(IDefenseComponent item) : base(item) { }
    public int Defense => Item.Defense;
    public static IDefenseFacade Get(int Defense) => new DefenseFacade(DefenseComponent.Get(Defense));
}