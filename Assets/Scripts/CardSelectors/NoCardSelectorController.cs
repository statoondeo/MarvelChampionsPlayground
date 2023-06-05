using System.Collections;
using System.Collections.Generic;
using System.Linq;

public sealed class NoCardSelectorController : BaseCardSelectorController
{
    public override IEnumerator Pick(IEnumerable<ICard> items, IPickReceiver<ICard> receiver, string title, string subTitle)
    {
        receiver.Receive(Enumerable.Empty<ICard>());
        yield return null;
    }
}