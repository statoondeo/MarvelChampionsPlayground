public sealed class VillainCardController : BaseCardController
{
    private VillainFaceController FaceController;
    private VillainFaceController BackController;

    protected override void Awake()
    {
        base.Awake();
        FaceController = FacePanelController.GetComponent<VillainFaceController>();
        BackController = BackPanelController.GetComponent<VillainFaceController>();
    }
    protected override void InitValues()
    {
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace(0))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(Card.CurrentFace as IVillainFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(Card.CurrentFace as IVillainFace);
            }
        }
        else
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
        }
    }
    public void DealDamage()
         => Card.Game.Enqueue(DealDamageCommand.Get(Card.Game, Card as IHeroCard, 1));
    public void HealDamage()
         => Card.Game.Enqueue(HealDamageCommand.Get(Card.Game, Card as IHeroCard, 1));
}
