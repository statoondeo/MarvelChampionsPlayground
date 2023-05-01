using System;
using System.Collections.Generic;

public sealed class Repository<TKey, TValue> : IRepository<TKey, TValue>
{
    private readonly IDictionary<TKey, TValue> Data;
    public int Count => Data.Count;
    public Repository() => Data = new Dictionary<TKey, TValue>();
    public bool TryGetValue(TKey key, out TValue value) => Data.TryGetValue(key, out value);
    public TValue Get(TKey key) 
    {
        if (Data.TryGetValue(key, out TValue value)) return value;
        return default;
    }
    public TValue Register(TKey key, TValue value)
    {
        Data.Add(key, value);
        return Data[key];
    }
    public void UnRegister(TKey key) => Data.Remove(key);
    public IEnumerable<TValue> Get() => Data.Values;
    public IEnumerable<TValue> Get(ISelector<TValue> selector)
    {
        foreach (TValue item in Data.Values)
            if (selector.Match(item)) yield return item;
    }
}
