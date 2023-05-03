using System.Collections.Generic;
using System.Linq;

public sealed class CardRepository : BaseRepository<ICard>
{
    public CardRepository() : base() { }
    public override IEnumerable<ICard> GetAll(ISelector<ICard> selector)
        => Data.Where(item => selector.Match(item)).OrderBy(item => item.Order);
}