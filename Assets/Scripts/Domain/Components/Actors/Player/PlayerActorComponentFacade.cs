using System.Collections.Generic;

public sealed class PlayerActorComponentFacade : BaseActorComponentFacade<IPlayerActorComponent>, IPlayerActorComponentFacade
{
    #region Constructor

    private PlayerActorComponentFacade(IPlayerActorComponent item)
        : base(item) { }

    #endregion

    #region IPlayerActorComponent

    public IEnumerable<ICard> EncounterCards => Item.EncounterCards;
    public void Draw(int number) => Item.Draw(number);

    #endregion

    #region Factory

    public static IPlayerActorComponentFacade Get()
        => new PlayerActorComponentFacade(PlayerActorComponent.Get());

    #endregion
}
