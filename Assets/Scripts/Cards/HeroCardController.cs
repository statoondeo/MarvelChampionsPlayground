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
        IHeroCard card = Card as IHeroCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace("FACE"))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.Faces["FACE"] as IAlterEgoFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(card.Faces["BACK"] as IHeroFace);
            }
            LifeController.gameObject.SetActive(true);
            LifeController.SetModel(card);
        }
        else
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
            LifeController.gameObject.SetActive(false);
        }
    }
    public void DealDamage() 
        => CompositeCommand.Get(
            DealDamageCommand.Get(Card.Game, Card as IHeroCard, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    public void HealDamage() 
        => CompositeCommand.Get(
            HealDamageCommand.Get(Card.Game, Card as IHeroCard, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
}
