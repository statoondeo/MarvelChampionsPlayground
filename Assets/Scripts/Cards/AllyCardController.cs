public sealed class AllyCardController : BaseCardController
{
    private AllyFaceController FaceController;
    private BackFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<AllyFaceController>();
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
                FaceController.SetModel(Card.CurrentFace as IAllyFace);
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
        if (Card.CurrentFace is not IAllyFace face) return;
        Card.Game.Enqueue(DealDamageCommand.Get(Card.Game, face, 1));
    }
    public void HealDamage()
    {
        if (Card.CurrentFace is not IAllyFace face) return;
        Card.Game.Enqueue(HealDamageCommand.Get(Card.Game, face, 1));
    }
}
