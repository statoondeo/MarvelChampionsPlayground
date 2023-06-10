using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public sealed class CardSelectorController : BaseCardSelectorController, IPicker<ICard>
{
    [SerializeField] private Canvas Canvas;
    [SerializeField] private TMP_Text TitleText;
    [SerializeField] private TMP_Text SubTitleText;

    private IList<ICard> SelectedCards;
    private bool Finished = false;
    private ISelectionMediator Mediator;

    private void Awake() => SelectedCards = new List<ICard>();
    public void SetSelectionMediator(ISelectionMediator mediator)
    {
        Mediator = mediator;
        Mediator.AddListener(SelectionEvent.OnItemSelected, OnItemSelectedCallback);
        Mediator.AddListener(SelectionEvent.OnItemUnSelected, OnItemUnSelectedCallback);
    }
    private void OnItemSelectedCallback(ISelectionEventParam eventParam)
        => SelectedCards.Add((eventParam as OnItemSelectionEventParam).Item);
    private void OnItemUnSelectedCallback(ISelectionEventParam eventParam)
        => SelectedCards.Remove((eventParam as OnItemSelectionEventParam).Item);
    public void EndSelection() => Finished = true;
    public override IEnumerator Pick(IEnumerable<ICard> items, IPickReceiver<ICard> receiver, string title, string subTitle)
    {
        yield return null;
    }
     public override IEnumerator Pick(ISelector<ICard> itemSelector, IPickReceiver<ICard> receiver, string title, string subTitle)
   {
        SelectedCards.Clear();
        Finished = false;
        TitleText.text = title;
        SubTitleText.text = subTitle;
        Canvas.gameObject.SetActive(true);
        Mediator.Raise(SelectionEvent.OnSelectionStarted, OnSelectionStartedEventParam.Get(itemSelector));
        yield return new WaitUntil(() => Finished);
        receiver.Receive(SelectedCards);
        Mediator.Raise(SelectionEvent.OnSelectionEnded, null);
        Canvas.gameObject.SetActive(false);
        yield return null;
    }
}
