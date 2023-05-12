﻿using TMPro;

using UnityEngine;

public sealed class ThwartController : BaseComponentController<IThwartComponent>
{
    [SerializeField] private TMP_Text Text;
    protected override void InitValues() => Text.text = Model.Thwart.ToString();
}