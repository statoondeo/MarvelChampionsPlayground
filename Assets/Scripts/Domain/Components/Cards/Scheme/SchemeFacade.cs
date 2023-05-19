public sealed class SchemeFacade : BaseCardComponentFacade<ISchemeComponent>, ISchemeFacade
{
    private SchemeFacade(ISchemeComponent item) : base(item) { }
    public int Scheme => Item.Scheme;
    public static ISchemeFacade Get(int Scheme) => new SchemeFacade(SchemeComponent.Get(Scheme));
}