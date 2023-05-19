using System.Collections.Generic;
using System.Linq;

public sealed class CardRepository : BaseRepository<ICard>
{
    private CardRepository() : base() { }
    public override IEnumerable<ICard> GetAll(ISelector<ICard> selector)
        => Data.Where(item => selector.Match(item)).OrderBy(item => item.Order);

    public static IRepository<ICard> Get() => new CardRepository();
}