﻿using UnityEngine;

public sealed class SupportCardController : BaseCardController
{
    [SerializeField] private SupportFaceController FaceController;
    [SerializeField] private BackFaceController BackController;

    protected override void OnFlippedCallback(string face)
    {
        base.OnFlippedCallback(face);
        FaceController.gameObject.SetActive(!Card.CurrentFace.IsCardType(CardType.None));
        BackController.gameObject.SetActive(!FaceController.gameObject.activeSelf);
    }
    public override void SetData(GameController gameController, RoutineController routineController, ICard card)
    {
        base.SetData(gameController, routineController, card);
        FaceController.SetModel(card.Faces.Get("FACE") as ISupportFace);
        BackController.SetModel(card.Faces.Get("BACK"));

        OnFlippedCallback(string.Empty);
    }
}