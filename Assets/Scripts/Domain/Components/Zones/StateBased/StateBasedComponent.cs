using System.Collections.Generic;
using System.Linq;

public sealed class StateBasedComponent : BaseZoneComponent<IStateBasedComponent>, IStateBasedComponent 
{
    private readonly IEnumerable<IStateBasedCommand> StateBasedCommands;
    private StateBasedComponent(params IStateBasedCommand[] stateBasedCommands) : base() 
        => StateBasedCommands = 
            stateBasedCommands is null || stateBasedCommands.Length == 0 
                ? Enumerable.Empty<IStateBasedCommand>() 
                :  stateBasedCommands;
    public IEnumerable<IStateBasedCommand> GetStateBasedCommands() => StateBasedCommands;
    public static IStateBasedComponent Get(params IStateBasedCommand[] stateBasedCommands) => new StateBasedComponent(stateBasedCommands);
}