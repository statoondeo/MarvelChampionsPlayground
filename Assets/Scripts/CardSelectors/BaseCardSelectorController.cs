using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class BaseCardSelectorController : MonoBehaviour, IPicker<ICard>
{
    public abstract IEnumerator Pick(IEnumerable<ICard> items, IPickReceiver<ICard> receiver, string title, string subTitle);
}
