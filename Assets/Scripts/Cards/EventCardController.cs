using UnityEngine;

public sealed class EventCardController : BaseCardController
{
    [SerializeField] private EventFaceController FaceController;
    [SerializeField] private BackFaceController BackController;

    protected override void OnFlippedCallback(IComponent component)
    {
        base.OnFlippedCallback(component);
        FaceController.gameObject.SetActive(!Card.CurrentFace.IsCardType(CardType.None));
        BackController.gameObject.SetActive(!FaceController.gameObject.activeSelf);
    }
    public override void SetData(GameController gameController, RoutineController routineController, ICard card)
    {
        base.SetData(gameController, routineController, card);
        FaceController.SetModel(card.Faces["FACE"] as IEventFace);
        BackController.SetModel(card.Faces["BACK"] as IBackFace);

        OnFlippedCallback(null);
    }
}
