﻿public sealed class SideSchemeCardController : BaseCardController
{
    private SideSchemeFaceController FaceController;
    private BackFaceController BackController;

    protected override void Awake()
    {
        base.Awake();
        FaceController = FacePanelController.GetComponent<SideSchemeFaceController>();
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
                FaceController.SetModel(Card.CurrentFace as ISideSchemeFace);
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
    public void AddTreat()
    {
        if (Card.CurrentFace is not ISideSchemeFace face) return;
        Card.Game.Enqueue(AddTreatCommand.Get(Card.Game, face, 1));
    }
    public void RemoveTreat()
    {
        if (Card.CurrentFace is not ISideSchemeFace face) return;
        Card.Game.Enqueue(RemoveTreatCommand.Get(Card.Game, face, 1));
    }
}
