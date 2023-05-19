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
        => CompositeCommand.Get(
            DealDamageCommand.Get(Card.Game, Card as IHeroCard, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    public void HealDamage() 
        => CompositeCommand.Get(
            HealDamageCommand.Get(Card.Game, Card as IHeroCard, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
}
