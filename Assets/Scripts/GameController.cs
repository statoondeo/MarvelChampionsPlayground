﻿using System;
using System.Collections;
using System.Collections.Generic;
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
    public IRepository<string, CardController> CardControllers { get; private set; }
    public IRepository<string, BaseZoneController> ZoneControllers { get; private set; }
    public IRepository<string, PlayerController> PlayerControllers { get; private set; }
    private CardController HeroController;
    private BaseZoneController BattlefieldController;

    private void CreatePlayerControllers()
    {
        PlayerControllers = new Repository<string, PlayerController>();
        foreach (IPlayer player in Game.Players)
        {
            PlayerController playerController = new GameObject(player.Title, typeof(PlayerController)).GetComponent<PlayerController>();
            playerController.transform.SetParent(transform);
            playerController.SetData(
                this,
                player,
                (PlayerDeckModel.Id == player.Id ? PlayerDeckModel : VillainDeckModel).SetupModel.InGameSetupModel.CardPositions);
            PlayerControllers.Register(playerController.Id, playerController);
        }
    }
    private void CreateZoneControllers()
    {
        ZoneControllers = new Repository<string, BaseZoneController>();
        foreach (IZone zone in Game.Zones)
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
            ZoneControllers.Register(zoneController.Id, zoneController);

            // Placement de la zone
            DeckModel deckModel = PlayerDeckModel.Id == zone.OwnerId ? PlayerDeckModel : VillainDeckModel;
            ZonePosition zonePosition = deckModel.SetupModel.InitialSetupModel.ZonePositions.FirstOrDefault(item => item.ZoneName.Equals(zone.Label));
            if (zonePosition is not null) Grid.Set(zonePosition.Position, zoneController);

            if (zoneController.Label == "BATTLEFIELD") BattlefieldController = zoneController;
        }
    }
    private void CreateCardControllers()
    {
        CardControllers = new Repository<string, CardController>();
        foreach (ICard card in Game.Cards)
        {
            CardController cardController = Instantiate(CardPrefab, transform).GetComponent<CardController>();
            cardController.SetData(this, card);
            CardControllers.Register(cardController.Id, cardController);
            if (card.IsOneOfCardType(CardType.AlterEgo, CardType.Hero)) HeroController = cardController;
        }
    }
    private void Awake()
    {
        RoutineService = gameObject.AddComponent<RoutineController>();

        Game = new GameBuilder()
            .WithPlayer(PlayerDeckModel)
            .WithPlayer(VillainDeckModel)
            .Build();

        Grid = new Grid(GridSize, CellSize);
        Game.Mediator.Register(Events.OnGameCommit, OnGameCommitCallback);

        CreatePlayerControllers();
        CreateZoneControllers();
        CreateCardControllers();

        foreach (BaseZoneController zoneController in ZoneControllers) zoneController.RefreshContent();

        RoutineService.StartGame();
    }
    public void Setup() => Game.Setup();
    private void OnGameCommitCallback(EventModelArg eventModelArg) => RoutineService.Commit();
}
