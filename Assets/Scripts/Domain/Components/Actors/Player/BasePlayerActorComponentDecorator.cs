using System.Collections.Generic;

public abstract class BasePlayerActorComponentDecorator : BaseActorComponentDecorator<IPlayerActorComponent>, IPlayerActorComponent
{
    #region ICoreActorComponent

    private IPlayerActorComponent InnerComponent => Inner as IPlayerActorComponent;
    public IEnumerable<ICard> EncounterCards => InnerComponent.EncounterCards;
    public void Draw(int number)=> InnerComponent.Draw(number);

    #endregion
}