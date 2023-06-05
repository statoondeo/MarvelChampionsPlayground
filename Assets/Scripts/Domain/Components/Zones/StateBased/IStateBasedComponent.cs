using System.Collections.Generic;

public interface IStateBasedComponent : IZoneComponent<IStateBasedComponent>
{
    IEnumerable<IStateBasedCommand> GetStateBasedCommands();
}
