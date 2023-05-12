﻿using TMPro;

using UnityEngine;

public sealed class RecoveryController : BaseComponentController<IRecoveryComponent>
{
    [SerializeField] private TMP_Text Text;
    protected override void InitValues() => Text.text = Model.Recovery.ToString();
}