using System;
using System.Collections.Generic;

public interface IRepository<TKey, TValue>
{
    TValue Register(TKey key, TValue value);
    TValue Get(TKey key);
    IEnumerable<TValue> Get();
    IEnumerable<TValue> Get(Func<TValue, bool> filter);
    void UnRegister(TKey key);
    IEnumerator<TValue> GetEnumerator();
    int Count { get; }
    bool TryGetValue(TKey key, out TValue value);
}
