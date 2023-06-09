﻿using System.Collections;
using System.Collections.Generic;

public abstract class BasePicker<T> : IPicker<T>
{
    protected BasePicker() { }
    public IEnumerator Pick(IEnumerable<T> items, IPickReceiver<T> receiver, string title, string subTitle)
    {
        receiver.Receive(items);
        yield return null;
    }
    public IEnumerator Pick(ISelector<T> itemSelector, IPickReceiver<T> receiver, string title, string subTitle)
    {
        receiver.Receive(null);
        yield return null;
    }
}