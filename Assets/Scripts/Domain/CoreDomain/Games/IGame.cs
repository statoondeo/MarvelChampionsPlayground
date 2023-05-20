public interface IGame :
    IRepository<IActor>,
    IRepository<IZone>,
    IRepository<ICard>
    //IGameMediator
{
    void Commit();
    void Setup();
    void RegisterSetupCommand(ICommand command);

    IPicker<ICard> AnyCardPicker { get; }
}
