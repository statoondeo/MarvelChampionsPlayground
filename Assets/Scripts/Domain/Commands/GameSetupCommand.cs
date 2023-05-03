public sealed class GameSetupCommand : ICommand
{
    private readonly ICommand Command;
    private GameSetupCommand(
            ICommand commitGameCommand,
            ICommand installHeroesCommand,
            ICommand setAsidePlayersObligationsCommand,
            ICommand setAsidePlayersNemesisSetCommand,
            ICommand shufflePlayersDecksCommand,
            ICommand installVillainsCommand,
            ICommand installMainSchemeCommand,
            ICommand resolveMainSchemeSetupCommand,
            ICommand resolveVillainBoardWhenRevealedCommand,
            ICommand shuffleVillainsDecksCommand,
            ICommand playersDrawHandCommand,
            ICommand playersMulliganCommand,
            ICommand playersSetupCommand
        )
        => Command = CompositeCommand.Get(
                installHeroesCommand, commitGameCommand,
                setAsidePlayersObligationsCommand, commitGameCommand,
                setAsidePlayersNemesisSetCommand, commitGameCommand,
                shufflePlayersDecksCommand, commitGameCommand,
                installVillainsCommand, commitGameCommand,
                installMainSchemeCommand, commitGameCommand,
                resolveMainSchemeSetupCommand, commitGameCommand,
                resolveVillainBoardWhenRevealedCommand, commitGameCommand,
                shuffleVillainsDecksCommand, commitGameCommand,
                playersDrawHandCommand, commitGameCommand,
                playersMulliganCommand, commitGameCommand,
                playersSetupCommand, commitGameCommand
            );
    public void Execute() => Command.Execute();
    public static ICommand Get(IGame game) 
        => new GameSetupCommand(
                CommitGameCommand.Get(game),
                BoardMulligansCommand.Get(game),
                BoardSetAsideNemesisSetCommand.Get(game),
                BoardSetAsideObligationsCommand.Get(game),
                ShufflePlayersDecksCommand.Get(game),
                InstallBoardVillainCommand.Get(game),
                InstallMainSchemeCommand.Get(game),
                MainSchemeSetupCommand.Get(game),
                ResolveVillainBoardWhenRevealedCommand.Get(game),
                ShuffleVillainsDecksCommand.Get(game),
                BoardDrawUpToHandCommand.Get(game),
                BoardMulligansCommand.Get(game),
                BoardHeroSetupCommand.Get(game)
            );
}