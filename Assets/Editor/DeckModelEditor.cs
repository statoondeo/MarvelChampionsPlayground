using System.Linq;

using UnityEditor;

using UnityEngine;

[CustomEditor(typeof(DeckModel))]
public class DeckModelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DeckModel deckModel = target as DeckModel;
        DrawDefaultInspector();
        if (GUILayout.Button("Display Cards"))
        {
            int deckSize = deckModel.HeroDeckComponentModel.CardModels.Length;
            deckModel.DeckComponentModels.ToList().ForEach(deck => deckSize += deck.CardModels.Length);
            deckModel.CardModels = new CardLocationModel[deckSize];
            int order = 0;
            deckModel.HeroDeckComponentModel.CardModels.ToList().ForEach(cardModel =>
            {
                deckModel.CardModels[order] = new CardLocationModel() { CardModel = cardModel, Location = "DECK", Order = order++ };
            });
            deckModel.DeckComponentModels.ToList().ForEach(deck =>
            {
                deck.CardModels.ToList().ForEach(cardModel =>
                {
                    deckModel.CardModels[order] = new CardLocationModel() { CardModel = cardModel, Location = "DECK", Order = order++ };
                });
            });
        }
    }
}
