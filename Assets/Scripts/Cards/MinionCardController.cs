public sealed class MinionCardController : BaseCardController
{
    private MinionFaceController FaceController;
    private BackFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<MinionFaceController>();
        BackController = BackPanelController.GetComponent<BackFaceController>();
    }
    protected override void InitValues()
    {
        IMinionCard card = Card as IMinionCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace(0))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.CurrentFace as IMinionFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(card.CurrentFace as IBackFace);
            }
        }
        else
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
        }
    }
    public void DealDamage()
    {
        if (Card.CurrentFace is not IMinionFace face) return;
        CompositeCommand.Get(
            DealDamageCommand.Get(Card.Game, face, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    }
    public void HealDamage()
    {
        if (Card.CurrentFace is not IMinionFace face) return;
        CompositeCommand.Get(
            HealDamageCommand.Get(Card.Game, face, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    }
}
