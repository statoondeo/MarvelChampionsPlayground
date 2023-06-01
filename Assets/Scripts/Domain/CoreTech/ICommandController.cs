using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public interface ICommandController
{
    void Enqueue(ICommand command);
    IEnumerator Execute();
}
public sealed class CommandController : ICommandController
{
    private readonly IList<ICommand> CommandsQueue;
    private CommandController() => CommandsQueue = new List<ICommand>();
    public void Enqueue(ICommand command) => CommandsQueue.Insert(0, command);
    public IEnumerator Execute()
    {
        while (true)
        {
            ICommand current;
            while (CommandsQueue.Count > 0)
            {
                current = CommandsQueue[0];
                yield return current.Execute();
                if (current.Executed) CommandsQueue.Remove(current);
            }
            yield return null;
        }
    }
    public static ICommandController Get() => new CommandController();
}