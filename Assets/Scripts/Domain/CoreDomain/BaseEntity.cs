public abstract class BaseEntity : IEntity
{
    public IGame Game { get; private set; }
    protected BaseEntity(IGame game) => Game = game;
}
