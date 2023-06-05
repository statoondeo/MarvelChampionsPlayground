using System.Collections;
using System.Collections.Generic;
using System.Linq;

public sealed class TransactionCommand : ICommand, ITransactionHandler
{
    private readonly ICommand Command;
    private readonly IGame Game;
    private int Step;
    private TransactionCommand(IGame game, ICommand command)
    {
        AnimationList = new List<IAnimation>();
        Game = game;
        Command = command;
        Step = 0;
    }
    public bool InProgress => Command.InProgress;
    public bool Executed => Command.Executed;
    public IEnumerator Execute()
    {
        switch (Step)
        {
            case 0:
                Game.RoutineController.StartTransaction(this);
                Game.Enqueue(Command);
                Step++;
                break;
            case 1:
                while (AnimationList.Any(animation => !animation.Ended)) yield return null;
                Step++;
                break;
            default:
                Game.RoutineController.StopTransaction();
                break;
        }
    }
    private readonly IList<IAnimation> AnimationList;
    public void AddAnimation(IAnimation animation) => AnimationList.Add(animation);

    public static ICommand Get(IGame game, ICommand command) 
        => new TransactionCommand(game, command);
}