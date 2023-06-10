public sealed class MinionCardController : BaseCardController
{
    private MinionFaceController FaceController;
    private BackFaceController BackController;

    protected override void Awake()
    {
        base.Awake();
        FaceController = FacePanelController.GetComponent<MinionFaceController>();
        BackController = BackPanelController.GetComponent<BackFaceController>();
    }
    protected override void InitValues()
    {
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace(0))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(Card.CurrentFace as IMinionFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(Card.CurrentFace as IBackFace);
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
        Card.Game.Enqueue(DealDamageCommand.Get(Card.Game, face, 1));
    }
    public void HealDamage()
    {
        if (Card.CurrentFace is not IMinionFace face) return;
        Card.Game.Enqueue(HealDamageCommand.Get(Card.Game, face, 1));
    }
}
