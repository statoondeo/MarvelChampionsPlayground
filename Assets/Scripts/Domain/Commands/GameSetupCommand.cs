public sealed class GameSetupCommand : ICommand
{
    private readonly ICommand Command;
    private GameSetupCommand(
            ICommand commitGameCommand,
            ICommand installHeroesCommand,
            ICommand setAsidePlayersObligationsCommand,
            ICommand setAsidePlayersNemesisSetCommand,
            ICommand shufflePlayersDecksCommand
        )
        => Command = CompositeCommand.Get(
                installHeroesCommand, commitGameCommand,
                setAsidePlayersObligationsCommand, commitGameCommand,
                setAsidePlayersNemesisSetCommand, commitGameCommand,
                shufflePlayersDecksCommand, commitGameCommand
            );
    public void Execute() => Command.Execute();
    public static ICommand Get(IGame game) 
        => new GameSetupCommand(
                CommitGameCommand.Get(game),
                InstallHeroesCommand.Get(game),
                SetAsidePlayersNemesisSetCommand.Get(game),
                SetAsidePlayersObligationsCommand.Get(game),
                ShufflePlayersDecksCommand.Get(game)
            );
}