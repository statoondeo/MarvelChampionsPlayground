using System;

public interface IGame :
    IRepository<IActor>,
    IRepository<IZone>,
    IRepository<ICard>,
    IPicker<ICard>,
    ICommandController,
    IStateBasedCommandController
{
    RoutineController RoutineController { get; set; }
    void Setup();
    Action OnSetupEnded { get; set; }
    void RegisterSetupCommand(ICommand command);
    int GetNumericValue(string value);
}
