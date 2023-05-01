public sealed class SchemeFacade : BaseComponentFacade<ISchemeComponent>, ISchemeFacade
{
    private SchemeFacade(ISchemeComponent item) : base(item) { }

    #region IScheme

    public int Scheme => Item.Scheme;

    #endregion

    public static ISchemeFacade Get(int Scheme) => new SchemeFacade(SchemeComponent.Get(Scheme));
}