using UnityEngine;

public sealed class HeroCardController : BaseCardController
{
    private AlterEgoFaceController FaceController;
    private HeroFaceController BackController;
    [SerializeField] private LifeController LifeController;
    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<AlterEgoFaceController>();
        BackController = BackPanelController.GetComponent<HeroFaceController>();
    }
    protected override void InitValues()
    {
        IHeroCard heroCard = Card as IHeroCard;
        if (Card.IsLocation("BATTLEFIELD") && Card.CurrentFace.IsCardType(CardType.AlterEgo))
        {
            FacePanelController.SetActive(true);
            FaceController.SetModel(heroCard.Faces["FACE"] as IAlterEgoFace);
        }
        else
        {
            FacePanelController.SetActive(false);
        }
        if (Card.IsLocation("BATTLEFIELD") && Card.CurrentFace.IsCardType(CardType.Hero))
        {
            BackPanelController.SetActive(true);
            BackController.SetModel(heroCard.Faces["BACK"] as IHeroFace);
        }
        else
        {
            BackPanelController.SetActive(false);
        }
        if (Card.IsLocation("BATTLEFIELD"))
        {
            LifeController.gameObject.SetActive(true);
            LifeController.SetModel(heroCard);
        }
        else
        {
            LifeController.gameObject.SetActive(false);
        }
    }
    public void DealDamage() => (Card as IHeroCard).TakeDamage(1);
}
