using UnityEngine;

public sealed class MainSchemeCardController : BaseCardController
{
    [SerializeField] private MainSchemeAFaceController FaceController;
    [SerializeField] private MainSchemeBFaceController BackController;

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
