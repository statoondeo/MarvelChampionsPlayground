using System.Linq;

using TMPro;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;
public sealed class TestGameController : MonoBehaviour
{
    [SerializeField] private PrefabAtlasModel PrefabAtlasModel;

    [SerializeField] private Canvas ActionsPanel;
    [SerializeField] private DeckModel DeckModel;
    [SerializeField] private TMP_Text LocationIdText;
    [SerializeField] private TMP_Text LocationLabelText;

    private BaseCardController CardController;
    private ICard Card;

    public void CreateObject(string cardTypeString)
    {
        if (CardController is not null)
        {
            Card.RemoveListener<ILocationComponent>(OnLocationChanged);
            Destroy(CardController.gameObject);
        }

        CardType cardType = ConvertToCardType(cardTypeString);
        CardController = Instantiate(PrefabAtlasModel.GetPrefab(cardTypeString), transform).GetComponent<BaseCardController>();
        RoutineController routineController = CardController.transform.AddComponent<RoutineController>();
        routineController.StartGame();

        Card = new GameBuilder(null).WithPlayer(DeckModel).Build().GetFirst(CardTypeSelector.Get(cardType));
        StartCoroutine(Card.Game.Execute());
        CardController.SetData(null, routineController, Card);
        Card.AddListener<ILocationComponent>(OnLocationChanged);

        OnLocationChanged(null);
        ActionAssociation();
    }
    private CardType ConvertToCardType(string cardType)
        => cardType switch
        {
            "Hero" => CardType.Hero,
            "Ally" => CardType.Ally,
            "Minion" => CardType.Minion,
            "SideScheme" => CardType.SideScheme,
            "MainScheme" => CardType.MainScheme,
            "Villain" => CardType.Villain,
            "Attachment" => CardType.Attachment,
            "Environment" => CardType.Environment,
            "Support" => CardType.Support,
            "Upgrade" => CardType.Upgrade,
            "Event" => CardType.Event,
            "Resource" => CardType.Resource,
            "Treachery" => CardType.Treachery,
            "Obligation" => CardType.Obligation,
            _ => CardType.None
        };
    private void OnLocationChanged(IComponent component)
    {
        LocationIdText.text = Card.Location;
        LocationLabelText.text = Card.Game.GetFirst(ZoneIdSelector.Get(Card.Location)).Label;
    }
    private void AttachDealDamageListener(Button button)
    {
        button.interactable = true;
        switch (Card.CardType)
        {
            case CardType.Villain:
                button.onClick.AddListener((CardController as VillainCardController).DealDamage);
                break;
            case CardType.Hero:
                button.onClick.AddListener((CardController as HeroCardController).DealDamage);
                break;
            case CardType.Ally:
                button.onClick.AddListener((CardController as AllyCardController).DealDamage);
                break;
            case CardType.Minion:
                button.onClick.AddListener((CardController as MinionCardController).DealDamage);
                break;
            default:
                button.interactable = false;
                break;
        }
    }
    private void AttachHealDamageListener(Button button)
    {
        button.interactable = true;
        switch (Card.CardType)
        {
            case CardType.Villain:
                button.onClick.AddListener((CardController as VillainCardController).HealDamage);
                break;
            case CardType.Hero:
                button.onClick.AddListener((CardController as HeroCardController).HealDamage);
                break;
            case CardType.Ally:
                button.onClick.AddListener((CardController as AllyCardController).HealDamage);
                break;
            case CardType.Minion:
                button.onClick.AddListener((CardController as MinionCardController).HealDamage);
                break;
            default:
                button.interactable = false;
                break;
        }
    }
    private void AttachAddTreatListener(Button button)
    {
        button.interactable = true;
        switch (Card.CardType)
        {
            case CardType.SideScheme:
                button.onClick.AddListener((CardController as SideSchemeCardController).AddTreat);
                break;
            case CardType.MainScheme:
                button.onClick.AddListener((CardController as MainSchemeCardController).AddTreat);
                break;
            default:
                button.interactable = false;
                break;
        }
    }
    private void AttachRemoveTreatLIstener(Button button)
    {
        button.interactable = true;
        switch (Card.CardType)
        {
            case CardType.SideScheme:
                button.onClick.AddListener((CardController as SideSchemeCardController).RemoveTreat);
                break;
            case CardType.MainScheme:
                button.onClick.AddListener((CardController as MainSchemeCardController).RemoveTreat);
                break;
            default:
                button.interactable = false;
                break;
        }
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
                    AttachDealDamageListener(button);
                    break;
                case "HealDamageButton":
                    AttachHealDamageListener(button);
                    break;
                case "AddTreatButton":
                    AttachAddTreatListener(button);
                    break;
                case "RemoveTreatButton":
                    AttachRemoveTreatLIstener(button);
                    break;
            }
        }
    }
}
