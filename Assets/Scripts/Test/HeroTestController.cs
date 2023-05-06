using Unity.VisualScripting;

using UnityEngine;

public sealed class HeroTestController : MonoBehaviour
{
    [SerializeField] private HeroCardModel HeroModel;
    private BaseCardController CardController;
    private IHeroCard HeroCard;
    private IGame Game;
    private RoutineController RoutineController;
    private void Awake()
    {
        CardController = GetComponent<BaseCardController>();
        Game = new GameBuilder(null).Build();
        HeroCard = new CardFactory().Create(Game, string.Empty, string.Empty, HeroModel) as IHeroCard;
        RoutineController = transform.AddComponent<RoutineController>();
        RoutineController.StartGame();
        CardController.SetData(null, RoutineController, HeroCard);
    }
    private void OnEnable() => Game.Register(GameEvents.OnCommitted, OnGameCommitCallback);
    private void OnDisable() => Game.UnRegister(GameEvents.OnCommitted, OnGameCommitCallback);
    private void OnGameCommitCallback(IGameArg eventModelArg) => RoutineController.Commit();

}
