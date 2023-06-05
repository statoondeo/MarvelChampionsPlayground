public interface ICardComponent : IComponent, ICardHolder { }
public interface ICardComponent<T> : ICardComponent/*, IFacadeHolder<T> */ where T : ICardComponent { }
