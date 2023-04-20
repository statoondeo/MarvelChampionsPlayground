public interface IScheme { int Scheme { get; } }
public sealed class SchemeComponent : IScheme
{
    public int Scheme { get; private set; }
    public SchemeComponent(int scheme) => Scheme = scheme;
}