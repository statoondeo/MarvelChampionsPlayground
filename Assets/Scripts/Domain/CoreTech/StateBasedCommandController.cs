using System.Collections.Generic;

public sealed class StateBasedCommandController : IStateBasedCommandController
{
    private readonly List<IStateBasedCommand> StateBasedCommandsList;
    private StateBasedCommandController() => StateBasedCommandsList = new List<IStateBasedCommand>();
    public void RegisterStateBasedCommand(IStateBasedCommand command) => StateBasedCommandsList.Add(command);
    public void UnRegisterStateBasedCommand(IStateBasedCommand command) => StateBasedCommandsList.Remove(command);
    public void CheckStateBasedCommand()
    {
        bool loop;
        do
        {
            loop = false;
            StateBasedCommandsList.ForEach(command =>
            {
                bool executeResult = command.Execute();
                //loop = loop || executeResult;
            });
        } while (loop);
    }
    public static IStateBasedCommandController Get() => new StateBasedCommandController();
}