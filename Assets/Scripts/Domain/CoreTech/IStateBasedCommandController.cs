public interface IStateBasedCommandController
{
    void CheckStateBasedCommand();
    void RegisterStateBasedCommand(IStateBasedCommand command);
    void UnRegisterStateBasedCommand(IStateBasedCommand command);
}
