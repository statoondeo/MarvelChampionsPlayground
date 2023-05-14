using UnityEngine;

public sealed class MainSchemeCardController : BaseCardController
{
    [SerializeField] private MainSchemeAFaceController FaceController;
    [SerializeField] private MainSchemeBFaceController BackController;

    public void AddTreat() => (Card.CurrentFace as IMainSchemeBFace)?.AddTreat(1);
    public void RemoveTreat() => (Card.CurrentFace as IMainSchemeBFace)?.RemoveTreat(1);
}
