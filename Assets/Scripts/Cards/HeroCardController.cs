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
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace(0))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(Card.CurrentFace as IAlterEgoFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(Card.CurrentFace as IHeroFace);
            }
            LifeController.gameObject.SetActive(true);
            LifeController.SetModel(Card as IHeroCard);
        }
        else
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
            LifeController.gameObject.SetActive(false);
        }
    }
    public void DealDamage()
        => Card.Game.Enqueue(DealDamageCommand.Get(Card.Game, Card as IHeroCard, 1));
    public void HealDamage()
        => Card.Game.Enqueue(HealDamageCommand.Get(Card.Game, Card as IHeroCard, 1));
}
