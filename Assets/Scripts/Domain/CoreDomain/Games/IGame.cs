public interface IGame :
    IRepository<IActor>,
    IRepository<IZone>,
    IRepository<ICard>,
    IPicker<ICard>,
    ICommandController
{
    RoutineController RoutineController { get; set; }
    void Setup();
    void RegisterSetupCommand(ICommand command);
}
