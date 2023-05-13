using TMPro;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

using static UnityEditor.FilePathAttribute;

public sealed class HeroTestController : MonoBehaviour
{
    [SerializeField] private DeckModel DeckModel;
    [SerializeField] private CardType CardType;
    [SerializeField] private Canvas ActionsPanel;
    [SerializeField] private TMP_Text LocationIdText;
    [SerializeField] private TMP_Text LocationLabelText;

    private BaseCardController CardController;
    private ICard Card;
    private IGame Game;
    private RoutineController RoutineController;
    private void Awake()
    {
        CardController = GetComponent<BaseCardController>();
        Game = new GameBuilder(null).WithPlayer(DeckModel).Build();
        Card = Game.GetFirst(CardTypeSelector.Get(CardType));
        RoutineController = transform.AddComponent<RoutineController>();
        RoutineController.StartGame();
    }
    private void Start()
    {
        CardController.SetData(null, RoutineController, Card);
        Card.AddListener<ILocationComponent>(OnLocationChanged);
        OnLocationChanged(null);
        ActionAssociation();
    }
    private void OnLocationChanged(IComponent component)
    {
        LocationIdText.text = Card.Location;
        LocationLabelText.text = Game.GetFirst(ZoneIdSelector.Get(Card.Location))?.Label;
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
                case "MoveToDiscardButton":
                    button.onClick.AddListener(() => CardController.MoveTo("DISCARD"));
                    break;
                case "MoveToBattlefieldButton":
                    button.onClick.AddListener(() => CardController.MoveTo("BATTLEFIELD"));
                    break;
                case "DealDamageButton":
                    switch (Card.CardType) {
                        case CardType.Villain:
                            button.onClick.AddListener((CardController as VillainCardController).DealDamage);
                            break;
                        case CardType.AlterEgo:
                        case CardType.Hero:
                            button.onClick.AddListener((CardController as HeroCardController).DealDamage);
                            break;
                        default:
                            if (Card.Faces["FACE"].IsCardType(CardType.Ally))
                                button.onClick.AddListener((CardController as AllyCardController).DealDamage);
                            else if (Card.Faces["FACE"].IsCardType(CardType.Minion))
                                button.onClick.AddListener((CardController as MinionCardController).DealDamage);
                            else
                                Debug.Log("No Damage");
                            break;
                    }
                    break;
            }
        }
    }
}
