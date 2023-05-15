public sealed class CommitRoutineCommand : ICommand
{
    private readonly RoutineController RoutineController;
    private CommitRoutineCommand(RoutineController routineController) => RoutineController = routineController;
    public void Execute() => RoutineController.Commit();
    public static ICommand Get(RoutineController routineController) 
        => new CommitRoutineCommand(routineController);
}
