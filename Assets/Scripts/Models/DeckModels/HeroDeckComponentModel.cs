using System;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Hero Deck Component")]
public sealed class HeroDeckComponentModel : ScriptableObject
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public HeroType HeroType;
    [SerializeField] private CardModel[] CardModels;
    [SerializeField] private HeroSetupModel HeroSetupModel;
    public IEnumerator<CardModel> GetEnumerator()
    {
        if ((CardModels is null) || (CardModels.Length == 0)) yield break;
        for (int i = 0; i < CardModels.Length; i++) yield return CardModels[i];
    }
    public HeroSetupModel SetupModel => HeroSetupModel;
}
public enum HeroType
{
    Hero,
    Villain,
}