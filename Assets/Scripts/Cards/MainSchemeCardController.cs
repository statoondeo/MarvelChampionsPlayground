using UnityEngine;

public sealed class MainSchemeCardController : BaseCardController
{
    [SerializeField] private MainSchemeAFaceController FaceController;
    [SerializeField] private MainSchemeBFaceController BackController;

    protected override void OnFlippedCallback(IFlipComponent component)
    {
        base.OnFlippedCallback(component);
        FaceController.gameObject.SetActive(!Card.CurrentFace.IsCardType(CardType.None));
        BackController.gameObject.SetActive(!FaceController.gameObject.activeSelf);
    }

    public override void SetData(GameController gameController, RoutineController routineController, ICard card)
    {
        base.SetData(gameController, routineController, card);
        FaceController.SetModel(card.Faces.Get("FACE") as IMainSchemeAFace);
        BackController.SetModel(card.Faces.Get("BACK") as IMainSchemeBFace);

        OnFlippedCallback(null);
    }
}
