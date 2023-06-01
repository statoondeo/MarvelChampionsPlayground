using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public sealed class CardSelectorController : MonoBehaviour, IPicker<ICard>
{
    [SerializeField] private GameObject CardSelectorItemPrefab;
    [SerializeField] private Canvas Canvas;
    [SerializeField] private Transform Content;

    private CardSelectorItemController[] CardSelectorItemControllers;
    private bool Finished;

    private IEnumerable<ICard> GetSelectedCards() 
        => CardSelectorItemControllers
            .Where(item => item.Selected)
            .Select(item => item.Card);
    public void EndSelection() => Finished = true;
    public IEnumerator Pick(IEnumerable<ICard> items, IPickReceiver<ICard> receiver)
    {
        Finished = false;
        CardSelectorItemControllers = new CardSelectorItemController[items.Count()];
        for (int i = 0; i < CardSelectorItemControllers.Length; i++)
        {
            CardSelectorItemControllers[i] = Instantiate(CardSelectorItemPrefab, Content).GetComponent<CardSelectorItemController>();
            CardSelectorItemControllers[i].SetCard(items.ElementAt(i));
        }
        Canvas.gameObject.SetActive(true);
        yield return new WaitUntil(() => Finished);
        Canvas.gameObject.SetActive(false);
        receiver.Receive(GetSelectedCards());
        yield return null;
    }
}