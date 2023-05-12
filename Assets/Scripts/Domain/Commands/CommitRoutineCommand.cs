public sealed class CommitRoutineCommand : ICommand
{
    private readonly RoutineController RoutineController;
    private CommitRoutineCommand(RoutineController routineController) => RoutineController = routineController;
    public void Execute() => RoutineController.Commit();
    private static ICommand Command;
    public static ICommand Get(RoutineController routineController) 
        => Command is null ? Command = new CommitRoutineCommand(routineController) : Command;
}
