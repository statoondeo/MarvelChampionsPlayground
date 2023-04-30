public interface ISetupComponent : IComponent<ISetupComponent>
{
    ICommand Setup { get; }
}
