public interface IClassification
{
    Classification Classification { get; }
    bool IsClassification(Classification classification);
}
public enum Classification
{
    None,
    Hero,
    Villain,
    Nemesis,
    Modular,
    Aggression,
    Justice,
    Leadership,
    Protection,
    Basic,
    Standard
}