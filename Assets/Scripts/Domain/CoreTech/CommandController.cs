using System.Collections;
using System.Collections.Generic;
using System.Text;

public sealed class CommandController : ICommandController
{
    private readonly IList<ICommand> CommandsQueue;
    private readonly IStateBasedCommandController StateBasedCommandController;
    private bool InProgress;
    private CommandController(IStateBasedCommandController stateBasedCommandController)
    {
        CommandsQueue = new List<ICommand>();
        StateBasedCommandController = stateBasedCommandController;
        InProgress = false;
    }
    public void Enqueue(ICommand command) => CommandsQueue.Insert(0, command);
    public bool IsCommandInQueue(ICommand command) => CommandsQueue.Contains(command);
    public IEnumerator Execute()
    {
        while (true)
        {
            ICommand current;
            while (CommandsQueue.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                current = CommandsQueue[0];
                //sb.AppendLine($"Execute -> {current.GetType().Name}");
                //foreach (ICommand command in CommandsQueue)
                //    sb.AppendLine($"\t Next -> {command.GetType().Name}");
                //Debug.Log(sb.ToString());
                yield return current.Execute();
                if (current.Executed) CommandsQueue.Remove(current);
                if (InProgress) StateBasedCommandController.CheckStateBasedCommand();
            }
            yield return null;
        }
    }
    public void Start() => InProgress = true;
    public void Stop() => InProgress = false;
    public static ICommandController Get(IStateBasedCommandController stateBasedCommandController) 
        => new CommandController(stateBasedCommandController);
}
