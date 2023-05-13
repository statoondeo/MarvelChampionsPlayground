public interface IComponent : ICardHolder 
{
    void Init();
}
public interface IComponent<T> : IComponent { }
