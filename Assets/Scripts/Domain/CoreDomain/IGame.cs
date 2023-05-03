public interface IGame :
    IRepository<IPlayer>,
    IRepository<IZone>,
    IRepository<ICard>,
    IMediator
{
    void Commit();
    void Setup();
    void RegisterSetupCommand(ICommand command);

    IPicker<ICard> AnyCardPicker { get; }
}
