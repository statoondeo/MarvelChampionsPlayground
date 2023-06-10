using System.Collections.Generic;

public sealed class StandardCardPickReceiver : IPickReceiver<ICard>
{
    private StandardCardPickReceiver() { }
    public IEnumerable<ICard> SelectedItems { get; private set; }
    public void Receive(IEnumerable<ICard> items) => SelectedItems = items;
    public static IPickReceiver<ICard> Get() => new StandardCardPickReceiver();
}