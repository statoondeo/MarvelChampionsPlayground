﻿using System.Collections;
using System.Collections.Generic;

public abstract class BasePicker<T> : IPicker<T>
{
    protected BasePicker() { }
    public IEnumerator Pick(IEnumerable<T> items, IPickReceiver<T> receiver)
    {
        receiver.Receive(items);
        yield return null;
    }
}