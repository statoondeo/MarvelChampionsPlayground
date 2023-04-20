using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Playable Deck")]
public class DeckModel : ScriptableObject
{
    [SerializeField] private HeroDeckComponentModel HeroDeckComponentModel;
    [SerializeField] private DeckComponentModel[] DeckComponentModels;
    public IEnumerator<CardModel> GetEnumerator()
    {
        if (HeroDeckComponentModel is null) yield break;
        foreach (CardModel cardmodel in HeroDeckComponentModel)
            yield return cardmodel;
        if ((DeckComponentModels is null) || (DeckComponentModels.Length == 0)) yield break;
        foreach (DeckComponentModel deckComponentModel in DeckComponentModels) 
            foreach (CardModel cardmodel in deckComponentModel)
                yield return cardmodel;
    }
    public string Id => HeroDeckComponentModel.Id;
    public HeroType HeroType => HeroDeckComponentModel.HeroType;
    public HeroSetupModel SetupModel => HeroDeckComponentModel.SetupModel;
}
