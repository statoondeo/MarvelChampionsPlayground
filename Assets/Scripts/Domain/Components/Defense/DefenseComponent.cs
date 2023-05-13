﻿public sealed class DefenseComponent : BaseComponent<IDefenseComponent>, IDefenseComponent
{ 
    public int Defense { get; private set; }
    public DefenseComponent(int defence) : base()
    {
        Defense = defence;
    }
    public static IDefenseComponent Get(int defence) => new DefenseComponent(defence);
}
