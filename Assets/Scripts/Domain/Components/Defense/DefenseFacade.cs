public sealed class DefenseFacade : BaseComponentFacade<IDefenseComponent>, IDefenseFacade
{
    private DefenseFacade(IDefenseComponent item) : base(item) { }

    #region IDefense

    public int Defense => Item.Defense;

    #endregion

    public static IDefenseFacade Get(int Defense) => new DefenseFacade(DefenseComponent.Get(Defense));
}