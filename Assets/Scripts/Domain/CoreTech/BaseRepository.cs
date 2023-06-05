using System.Collections.Generic;
using System.Linq;

public abstract class BaseRepository<TValue> : IRepository<TValue>
{
    protected readonly ISet<TValue> Data;
    protected BaseRepository() => Data = new HashSet<TValue>();
    public virtual void Add(TValue item) => Data.Add(item);
    public virtual bool Contains(TValue item) => Data.Contains(item);
    public virtual int Count(ISelector<TValue> selector) => GetAll(selector).Count();
    public virtual IEnumerable<TValue> GetAll(ISelector<TValue> selector) => Data.Where(item => selector.Match(item));
    public virtual TValue GetFirst(ISelector<TValue> selector) => GetAll(selector).FirstOrDefault();
    public virtual void Remove(TValue item) => Data.Remove(item);
    public virtual TValue GetLast(ISelector<TValue> selector) => GetAll(selector).LastOrDefault();
    public virtual TValue GetAt(ISelector<TValue> selector, int index) => GetAll(selector).ElementAt(index);
}
