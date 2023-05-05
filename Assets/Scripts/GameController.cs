using System.Linq;

using UnityEngine;
public sealed class GameController : MonoBehaviour
{
    [SerializeField] private Vector2Int GridSize;
    [SerializeField] private Vector2 CellSize;
    [SerializeField] private DeckModel PlayerDeckModel;
    [SerializeField] private DeckModel VillainDeckModel;
    [SerializeField] private GameObject CardPrefab;
    [SerializeField] private GameObject BattlefieldPrefab;
    [SerializeField] private GameObject HandPrefab;
    [SerializeField] private GameObject DeckPrefab;
    [SerializeField] private GameObject StackPrefab;

    public RoutineController RoutineService { get; private set; }
    private IGame Game;
    public IGrid Grid { get; private set; }
    public IRepository<BaseCardController> CardControllers { get; private set; }
    public IRepository<BaseZoneController> ZoneControllers { get; private set; }
    public IRepository<PlayerController> PlayerControllers { get; private set; }
    private BaseCardController HeroController;
    private BaseZoneController BattlefieldController;
    private CardPickerController CardPickerController;

    private void CreatePlayerControllers()
    {
        PlayerControllers = new PlayerControllerRepository();
        foreach (IPlayer player in Game.GetAll(NoFilterPlayerSelector.Get()))
        {
            PlayerController playerController = new GameObject(player.Title, typeof(PlayerController)).GetComponent<PlayerController>();
            playerController.transform.SetParent(transform);
            playerController.SetData(
                this,
                player,
                (PlayerDeckModel.Id == player.Id ? PlayerDeckModel : VillainDeckModel).SetupModel.InGameSetupModel.CardPositions);
            PlayerControllers.Add(playerController);
        }
    }
    private void CreateZoneControllers()
    {
        ZoneControllers = new BaseZoneControllerRepository();
        foreach (IZone zone in Game.GetAll(NoFilterZoneSelector.Get()))
        {
            GameObject zoneModel = zone.Label switch
            {
                "BATTLEFIELD" => BattlefieldPrefab,
                "HAND" => HandPrefab,
                "DECK" => DeckPrefab,
                _ => StackPrefab,
            };
            BaseZoneController zoneController = Instantiate(zoneModel, transform).GetComponent<BaseZoneController>();
            zoneController.SetData(this, zone);
            ZoneControllers.Add(zoneController);

            // Placement de la zone
            DeckModel deckModel = PlayerDeckModel.Id == zone.OwnerId ? PlayerDeckModel : VillainDeckModel;
            ZonePosition zonePosition = deckModel.SetupModel.InitialSetupModel.ZonePositions.FirstOrDefault(item => item.ZoneName.Equals(zone.Label));
            if (zonePosition is not null) Grid.Set(zonePosition.Position, zoneController);

            if (zoneController.Label == "BATTLEFIELD") BattlefieldController = zoneController;
        }
    }
    private void CreateCardControllers()
    {
        CardControllers = new BaseCardControllerRepository();
        foreach (ICard card in Game.GetAll(NoFilterCardSelector.Get()))
        {
            BaseCardController cardController = Instantiate(CardPrefab, transform).GetComponent<BaseCardController>();
            cardController.SetData(this, RoutineService, card);
            CardControllers.Add(cardController);
            if (card.IsCardType(CardType.AlterEgo) || card.IsCardType(CardType.Hero)) HeroController = cardController;
        }
    }
    private void Awake()
    {
        RoutineService = gameObject.AddComponent<RoutineController>();
        CardPickerController = gameObject.AddComponent<CardPickerController>();
        
        Game = new GameBuilder(CardPickerController)
            .WithPlayer(PlayerDeckModel)
            .WithPlayer(VillainDeckModel)
            .Build();

        Grid = new Grid(GridSize, CellSize);
        //Game.Register(Events.OnGameCommit, OnGameCommitCallback);

        CreatePlayerControllers();
        CreateZoneControllers();
        CreateCardControllers();

        foreach (BaseZoneController zoneController in ZoneControllers.GetAll(NoFilterBaseZoneControllerSelector.Get())) 
            zoneController.RefreshContent();

        RoutineService.StartGame();
    }
    public void Setup() => Game.Setup();
    //private void OnGameCommitCallback(EventModelArg eventModelArg) => RoutineService.Commit();
}
