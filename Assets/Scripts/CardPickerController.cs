using System.Collections.Generic;

using UnityEngine;

public sealed class CardPickerController : MonoBehaviour, IPicker<ICard>
{
    public IEnumerable<ICard> Pick(IEnumerable<ICard> items) => items;
}
