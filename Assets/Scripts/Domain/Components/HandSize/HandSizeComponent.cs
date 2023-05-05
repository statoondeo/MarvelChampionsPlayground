﻿public sealed class HandSizeComponent : BaseComponent<IHandSizeComponent>, IHandSizeComponent
{
    public int HandSize { get; private set; }
    public HandSizeComponent(int handSize) : base()
    {
        Type = ComponentType.HandSize;
        HandSize = handSize;
    }
    public static IHandSizeComponent Get(int handSize) => new HandSizeComponent(handSize);

}
