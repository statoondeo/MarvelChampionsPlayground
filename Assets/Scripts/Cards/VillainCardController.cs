public sealed class VillainCardController : BaseCardController
{
    private VillainFaceController FaceController;
    private VillainFaceController BackController;

    private void Awake()
    {
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
        => CompositeCommand.Get(
            DealDamageCommand.Get(Card.Game, Card.CurrentFace as IVillainFace, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    public void HealDamage()
        => CompositeCommand.Get(
            HealDamageCommand.Get(Card.Game, Card.CurrentFace as IVillainFace, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
}
