using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Deck Component")]
public sealed class DeckComponentModel : ScriptableObject
{
    [SerializeField] private CardModel[] CardModels;
    public IEnumerator<CardModel> GetEnumerator()
    {
        if ((CardModels is null) || (CardModels.Length == 0)) yield break;
        for (int i = 0; i < CardModels.Length; i++) yield return CardModels[i];
    }
}
