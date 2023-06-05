using System.Collections.Generic;

public sealed class StateBasedComponentFacade : BaseZoneComponentFacade<IStateBasedComponent>, IStateBasedComponentFacade
{
    #region Constructor

    private StateBasedComponentFacade(IStateBasedComponent item)
        : base(item) { }

    #endregion

    #region IStateBasedComponent

    public IEnumerable<IStateBasedCommand> GetStateBasedCommands() => Item.GetStateBasedCommands();

    #endregion

    #region Factory

    public static IStateBasedComponentFacade Get(params IStateBasedCommand[] stateBasedCommands)
        => new StateBasedComponentFacade(StateBasedComponent.Get(stateBasedCommands));

    #endregion
}