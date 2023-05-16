using UnityEngine;

public sealed class MainSchemeCardController : BaseCardController
{
    private MainSchemeAFaceController FaceController;
    private MainSchemeBFaceController BackController;

    private void Awake()
    {
        FaceController = FacePanelController.GetComponent<MainSchemeAFaceController>();
        BackController = BackPanelController.GetComponent<MainSchemeBFaceController>();
    }
    protected override void InitValues()
    {
        IMainSchemeCard card = Card as IMainSchemeCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace("FACE"))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.Faces["FACE"] as IMainSchemeAFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(card.Faces["BACK"] as IMainSchemeBFace);
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
        if (Card.CurrentFace is not IMainSchemeBFace face) return;
        CompositeCommand.Get(
            AddTreatCommand.Get(Card.Game, face, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    }
    public void RemoveTreat()
    {
        if (Card.CurrentFace is not IMainSchemeBFace face) return;
        CompositeCommand.Get(
            RemoveTreatCommand.Get(Card.Game, face, 1),
            CommitRoutineCommand.Get(RoutineController)).Execute();
    }
}
