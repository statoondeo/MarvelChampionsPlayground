using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public sealed class HeroTestController : MonoBehaviour
{
    [SerializeField] private CardModel HeroModel;
    [SerializeField] private Canvas ActionsPanel;

    private BaseCardController CardController;
    private ICard Card;
    private IGame Game;
    private RoutineController RoutineController;
    private void Awake()
    {
        CardController = GetComponent<BaseCardController>();
        Game = new GameBuilder(null).Build();
        Card = new CardFactory().Create(Game, string.Empty, string.Empty, HeroModel);
        RoutineController = transform.AddComponent<RoutineController>();
        RoutineController.StartGame();
    }
    private void Start()
    {
        CardController.SetData(null, RoutineController, Card);
        ActionAssociation();
    }
    private void ActionAssociation()
    {
        foreach (Button button in ActionsPanel.GetComponentsInChildren<Button>()) 
        {
            button.onClick.RemoveAllListeners();
            switch (button.name) 
            {
                case "TapButton":
                    button.onClick.AddListener(CardController.Tap);
                    break;
                case "UnTapButton":
                    button.onClick.AddListener(CardController.UnTap);
                    break;
                case "FlipButton":
                    button.onClick.AddListener(CardController.Flip);
                    break;
                case "UnflipButton":
                    button.onClick.AddListener(CardController.UnFlip);
                    break;
                case "MoveToDeckButton":
                    button.onClick.AddListener(() => CardController.MoveTo("DECK"));
                    break;
                case "MoveToBattlefieldButton":
                    button.onClick.AddListener(() => CardController.MoveTo("BATTLEFIELD"));
                    break;
                case "DealDamageButton":
                    switch (Card.CardType) {
                        case CardType.Ally:
                            button.onClick.AddListener((CardController as AllyCardController).DealDamage);
                            break;
                        case CardType.Minion:
                            button.onClick.AddListener((CardController as MinionCardController).DealDamage);
                            break;
                        case CardType.Villain:
                            button.onClick.AddListener((CardController as VillainCardController).DealDamage);
                            break;
                        case CardType.AlterEgo:
                        case CardType.Hero:
                            button.onClick.AddListener((CardController as HeroCardController).DealDamage);
                            break;
                        default:
                            Debug.Log("No Damage");
                            break;
                    }
                    break;
            }
        }
    }
    //private void OnEnable() => Game.Register(GameEvents.OnCommitted, OnGameCommitCallback);
    //private void OnDisable() => Game.UnRegister(GameEvents.OnCommitted, OnGameCommitCallback);
    //private void OnGameCommitCallback(IGameArg eventModelArg) => RoutineController.Commit();

}
