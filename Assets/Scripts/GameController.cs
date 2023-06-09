﻿using System.Collections;
using System.Linq;

using UnityEngine;
public sealed class GameController : MonoBehaviour
{
    [SerializeField] private Vector2Int GridSize;
    [SerializeField] private Vector2 CellSize;

    [SerializeField] private DeckModel PlayerDeckModel;
    [SerializeField] private DeckModel VillainDeckModel;

    [SerializeField] private PrefabAtlasModel CardPrefabAtlasModel;
    [SerializeField] private PrefabAtlasModel ZonePrefabAtlasModel;

    [SerializeField] private GameObject CardSelectorPrefab;

    [SerializeField] private SelectionController SelectionController;

    private CardSelectorController CardSelector;

    public RoutineController RoutineController { get; private set; }
    public IGame Game { get; private set; }
    public IGrid Grid { get; private set; }
    public IRepository<BaseCardController> CardControllers { get; private set; }
    public IRepository<BaseZoneController> ZoneControllers { get; private set; }
    public IRepository<PlayerController> PlayerControllers { get; private set; }

    private void CreatePlayerControllers()
    {
        PlayerControllers = new PlayerControllerRepository();
        foreach (IActor player in Game.GetAll(NoFilterActorSelector.Get()))
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
            string zoneName = zone.Label;
            if (zoneName.Equals("DECK", System.StringComparison.OrdinalIgnoreCase))
                zoneName = (PlayerDeckModel.Id == zone.OwnerId ? "Player" : "Villain") + zoneName;
            BaseZoneController zoneController = Instantiate(ZonePrefabAtlasModel.GetPrefab(zoneName), transform).GetComponent<BaseZoneController>();
            zoneController.SetData(this, zone);
            ZoneControllers.Add(zoneController);

            // Placement de la zone
            DeckModel deckModel = PlayerDeckModel.Id == zone.OwnerId ? PlayerDeckModel : VillainDeckModel;
            ZonePosition zonePosition = deckModel.SetupModel.InitialSetupModel.ZonePositions.FirstOrDefault(item => item.ZoneName.Equals(zone.Label));
            if (zonePosition is not null) Grid.Set(zonePosition.Position, zoneController);
        }
    }
    private void CreateCardControllers()
    {
        CardControllers = new BaseCardControllerRepository();
        foreach (ICard card in Game.GetAll(NoFilterCardSelector.Get()))
        {
            BaseCardController cardController = Instantiate(CardPrefabAtlasModel
                    .GetPrefab(card.CardType.ToString()), transform)
                    .GetComponent<BaseCardController>();
            cardController.SetData(this, RoutineController, SelectionController.Mediator, card);
            CardControllers.Add(cardController);
        }
    }
    private void Awake()
    {
        RoutineController = gameObject.AddComponent<RoutineController>();
        CardSelector = Instantiate(CardSelectorPrefab, transform).GetComponent<CardSelectorController>();
        CardSelector.SetSelectionMediator(SelectionController.Mediator);

        Game = new GameBuilder(CardSelector)
            .WithRoutineController(RoutineController)
            .WithPlayer(PlayerDeckModel)
            .WithPlayer(VillainDeckModel)
            .Build();
        Grid = new Grid(GridSize, CellSize);

        CreatePlayerControllers();
        CreateZoneControllers();
        CreateCardControllers();

        ZoneControllers
            .GetAll(NoFilterBaseZoneControllerSelector.Get())
            .ToList()
            .ForEach(controller => controller.RefreshContent());

        CardControllers
            .GetAll(NoFilterCardControllerSelector.Get())
            .ToList()
            .ForEach(controller => controller.InitController());
    }
    private IEnumerator Start()
    {
        yield return StartCoroutine(Game.Execute());
    }
}
