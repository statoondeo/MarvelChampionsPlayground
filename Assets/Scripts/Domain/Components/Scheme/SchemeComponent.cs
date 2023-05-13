public sealed class SchemeComponent : BaseComponent<ISchemeComponent>, ISchemeComponent
{
    public int Scheme { get; private set; }
    private SchemeComponent(int scheme) : base()
    {
        Scheme = scheme;
    }
    public static ISchemeComponent Get(int scheme) => new SchemeComponent(scheme);
}
