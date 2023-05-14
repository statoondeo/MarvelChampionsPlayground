﻿using UnityEngine;

public sealed class VillainCardController : BaseCardController
{
    [SerializeField] private VillainFaceController FaceController;
    [SerializeField] private VillainFaceController BackController;
    protected override void InitValues()
    {
        IVillainCard card = Card as IVillainCard;
        if (Card.IsLocation("BATTLEFIELD"))
        {
            if (Card.IsFace("FACE"))
            {
                BackPanelController.SetActive(false);
                FacePanelController.SetActive(true);
                FaceController.SetModel(card.Faces["FACE"] as IVillainFace);
            }
            else
            {
                FacePanelController.SetActive(false);
                BackPanelController.SetActive(true);
                BackController.SetModel(card.Faces["BACK"] as IVillainFace);
            }
        }
        else
        {
            FacePanelController.SetActive(false);
            BackPanelController.SetActive(false);
        }
    }
    public void DealDamage() => (Card.CurrentFace as IVillainFace)?.TakeDamage(1);
    public void HealDamage() => (Card.CurrentFace as IVillainFace)?.HealDamage(1);
}
