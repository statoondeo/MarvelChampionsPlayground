﻿public sealed class BoostFacade : BaseFacade<IBoostComponent>, IBoostFacade
{
    private BoostFacade(IBoostComponent item) : base(item) { }
    public int Boost => Item.Boost;
    public static IBoostFacade Get(int Boost) 
        => new BoostFacade(BoostComponent.Get(Boost));
}