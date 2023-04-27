public sealed class SchemeComponent : IScheme
{
    public int Scheme { get; private set; }
    private SchemeComponent(int scheme) => Scheme = scheme;
    public static IScheme Get(int scheme) => new SchemeComponent(scheme);
}