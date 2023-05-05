public sealed class SchemeComponent : BaseComponent<ISchemeComponent>, ISchemeComponent
{
    public int Scheme { get; private set; }
    private SchemeComponent(int scheme) : base()
    {
        Type = ComponentType.Scheme;
        Scheme = scheme;
    }
    public static ISchemeComponent Get(int scheme) => new SchemeComponent(scheme);
}
