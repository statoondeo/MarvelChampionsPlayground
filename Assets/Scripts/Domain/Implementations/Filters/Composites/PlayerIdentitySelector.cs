using System.Collections.Generic;
using System.Linq;

public sealed class PlayerIdentitySelector : ISelector<ICard>
{
    private readonly ISelector<ICard> Selector;
    private PlayerIdentitySelector(string ownerId)
        => Selector =
            AndCompositeSelector.Get(
                OwnerIdSelector.Get(ownerId),
                OrCompositeSelector.Get(
                    CardTypeSelector.Get(CardType.AlterEgo),
                    CardTypeSelector.Get(CardType.Hero)));
    public IEnumerable<ICard> Select(IEnumerable<ICard> cards) => Selector.Select(cards);
    public static ISelector<ICard> Get(string ownerId) => new PlayerIdentitySelector(ownerId);
}
public sealed class CommitGameCommand : BaseCommand
{
    private CommitGameCommand(IGame game) : base(game) { }
    public override void Execute() => Game.Commit();
    public static ICommand Get(IGame game) => new CommitGameCommand(game);
}
public abstract class BaseFunctionalCommand : BaseCommand
{
    protected BaseFunctionalCommand(IGame game) : base(game) { }
    protected virtual ISelector<ICard> GetCardSelector() => NoFilterSelector.Get();
    protected virtual ISelector<ICard> GetPlayerChoices() => NoFilterSelector.Get();
    protected virtual ICommand GetCardCommand(ICard card) => NullCommand.Get();
    protected virtual ICommand GetAdditionalCommand() => NullCommand.Get();
    public override void Execute()
    {
        foreach(ICard card in GetPlayerChoices().Select(GetCardSelector().Select(Game.Cards.Get())))
            GetCardCommand(card).Execute();
        GetAdditionalCommand().Execute();
    }
}
public sealed class InstallHeroCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private InstallHeroCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> GetCardSelector()
        => PlayerIdentitySelector.Get(PlayerId);
    protected override ICommand GetCardCommand(ICard card)
        => CompositeCommand.Get(
                MoveToCommand.Get(Game, card, "BATTLEFIELD"),
                FlipToCommand.Get(Game, card, "FACE"));
    public static ICommand Get(IGame game, string playerId) => new InstallHeroCommand(game, playerId);
}
public sealed class InstallHeroesCommand : BaseCommand
{
    private readonly ICommand Command;
    private InstallHeroesCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new List<ICommand>();
        Game.Players.Get(player => player.HeroType.Equals(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(InstallHeroCommand.Get(Game, item.Id)));
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new InstallHeroesCommand(game);
}
public sealed class SetAsidePlayerObligationsCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private SetAsidePlayerObligationsCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> GetCardSelector()
        => PlayerObligationSelector.Get(PlayerId);
    protected override ICommand GetCardCommand(ICard card)
        => CompositeCommand.Get(
                MoveToCommand.Get(Game, card, "EXIL"),
                FlipToCommand.Get(Game, card, "FACE"));
    public static ICommand Get(IGame game, string playerId) => new SetAsidePlayerObligationsCommand(game, playerId);
}
public sealed class SetAsidePlayersObligationsCommand : BaseCommand
{
    private readonly ICommand Command;
    private SetAsidePlayersObligationsCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new List<ICommand>();
        Game.Players.Get(player => player.HeroType.Equals(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(SetAsidePlayerObligationsCommand.Get(Game, item.Id)));
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new SetAsidePlayersObligationsCommand(game);
}
public sealed class SetAsidePlayerNemesisSetCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private SetAsidePlayerNemesisSetCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> GetCardSelector()
        => PlayerNemesisSetSelector.Get(PlayerId);
    protected override ICommand GetCardCommand(ICard card)
        => CompositeCommand.Get(
                MoveToCommand.Get(Game, card, "EXIL"),
                FlipToCommand.Get(Game, card, "FACE"));
    public static ICommand Get(IGame game, string playerId) => new SetAsidePlayerNemesisSetCommand(game, playerId);
}
public sealed class SetAsidePlayersNemesisSetCommand : BaseCommand
{
    private readonly ICommand Command;
    public SetAsidePlayersNemesisSetCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new List<ICommand>();
        Game.Players.Get(player => player.HeroType.Equals(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(SetAsidePlayerNemesisSetCommand.Get(Game, item.Id)));
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new SetAsidePlayersNemesisSetCommand(game);
}
public sealed class ShufflePlayersDecksCommand : BaseCommand
{
    private readonly ICommand Command;
    public ShufflePlayersDecksCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new List<ICommand>();
        Game.Players.Get(player => player.HeroType.Equals(HeroType.Hero)).ToList()
            .ForEach(item =>
            {
                commands.Add(ShuffleZoneCommand.Get(Game, item.GetZone("DECK")));
            });
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new ShufflePlayersDecksCommand(game);
}
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