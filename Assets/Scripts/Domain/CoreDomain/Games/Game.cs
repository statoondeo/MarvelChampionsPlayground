using System;
using System.Collections;
using System.Collections.Generic;

public sealed class Game : IGame
{
    private ICommand SetupCommand;
    public RoutineController RoutineController { get; set; }

    public Game(
        IRepository<IZone> zones,
        IRepository<ICard> cards, 
        IRepository<IActor> players,
        IPicker<ICard> cardPicker)
    {
        Zones = zones;
        Cards = cards;
        Players = players;
        CardPicker = cardPicker;
        StateBasedCommandControllerItem = StateBasedCommandController.Get();
        CommandControllerItem = CommandController.Get(StateBasedCommandControllerItem);
    }

    #region IRepository<IActor>

    private readonly IRepository<IActor> Players;
    public void Add(IActor item) => Players.Add(item);
    public void Remove(IActor item) => Players.Remove(item);
    public int Count(ISelector<IActor> selector) => Players.Count(selector);
    public bool Contains(IActor item) => Players.Contains(item);
    public IActor GetFirst(ISelector<IActor> selector) => Players.GetFirst(selector);
    public IEnumerable<IActor> GetAll(ISelector<IActor> selector) => Players.GetAll(selector);
    public IActor GetLast(ISelector<IActor> selector) => Players.GetLast(selector);
    public IActor GetAt(ISelector<IActor> selector, int index) => Players.GetAt(selector, index);

    #endregion

    #region IRepository<IZone>

    private readonly IRepository<IZone> Zones;
    public void Add(IZone item) => Zones.Add(item);
    public void Remove(IZone item) => Zones.Remove(item);
    public int Count(ISelector<IZone> selector) => Zones.Count(selector);
    public bool Contains(IZone item) => Zones.Contains(item);
    public IZone GetFirst(ISelector<IZone> selector) => Zones.GetFirst(selector);
    public IEnumerable<IZone> GetAll(ISelector<IZone> selector) => Zones.GetAll(selector);
    public IZone GetLast(ISelector<IZone> selector) => Zones.GetLast(selector);
    public IZone GetAt(ISelector<IZone> selector, int index) => Zones.GetAt(selector, index);

    #endregion

    #region ICardContainer

    private readonly IRepository<ICard> Cards;
    public void Add(ICard item) => Cards.Add(item);
    public void Remove(ICard item) => Cards.Remove(item);
    public int Count(ISelector<ICard> selector) => Cards.Count(selector);
    public bool Contains(ICard item) => Cards.Contains(item);
    public ICard GetFirst(ISelector<ICard> selector) => Cards.GetFirst(selector);
    public IEnumerable<ICard> GetAll(ISelector<ICard> selector) => Cards.GetAll(selector);
    public ICard GetLast(ISelector<ICard> selector) => Cards.GetLast(selector);
    public ICard GetAt(ISelector<ICard> selector, int index) => Cards.GetAt(selector, index);

    #endregion

    #region IPicker<ICard>

    private readonly IPicker<ICard> CardPicker;
    public IEnumerator Pick(IEnumerable<ICard> items, IPickReceiver<ICard> receiver, string title, string subTitle)
        => CardPicker.Pick(items, receiver, title, subTitle);

    #endregion

    #region ICommandController

    private readonly ICommandController CommandControllerItem;
    public void Enqueue(ICommand command) => CommandControllerItem.Enqueue(command);
    public IEnumerator Execute() => CommandControllerItem.Execute();
    public void Start() => CommandControllerItem.Start();
    public void Stop() => CommandControllerItem.Stop();
    public bool IsCommandInQueue(ICommand command) => CommandControllerItem.IsCommandInQueue(command);

    #endregion

    #region IStateBasedCommandController

    private readonly IStateBasedCommandController StateBasedCommandControllerItem;
    public void CheckStateBasedCommand() => StateBasedCommandControllerItem.CheckStateBasedCommand();
    public void RegisterStateBasedCommand(IStateBasedCommand command) 
        => StateBasedCommandControllerItem.RegisterStateBasedCommand(command);
    public void UnRegisterStateBasedCommand(IStateBasedCommand command) 
        => StateBasedCommandControllerItem.UnRegisterStateBasedCommand((IStateBasedCommand)command);

    #endregion

    public Action OnSetupEnded { get; set; }

    public void Setup()
    {
        Enqueue(new CustomCommand(() => OnSetupEnded?.Invoke()));
        Enqueue(SetupCommand);
    }

    public void RegisterSetupCommand(ICommand command) => SetupCommand = command;

    public int GetNumericValue(string value) 
        => value.Contains("P", StringComparison.OrdinalIgnoreCase) 
            ? int.Parse(value.Replace("P", string.Empty, StringComparison.OrdinalIgnoreCase)) * Count(PlayerTypeSelector.Get(HeroType.Hero)) 
            : int.Parse(value);
}
public sealed class CustomCommand : ICommand
{
    public bool InProgress {get; private set; }
    public bool Executed { get; private set; }
    private readonly Action ActionToExecute;
    public CustomCommand(Action actionToExecute)
    {
        ActionToExecute = actionToExecute;
        Executed = false;
    }
    public IEnumerator Execute()
    {
        ActionToExecute.Invoke();
        Executed = true;
        yield return null;
    }
}