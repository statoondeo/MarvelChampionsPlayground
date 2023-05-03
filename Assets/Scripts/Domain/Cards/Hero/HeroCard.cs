using System;

public sealed class HeroCard : BaseCard, IHeroCard
{
    public HeroCard(IGame game, ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade, ILifeFacade lifeFacade)
        : base(game, coreCardFacade, flipFacade, tapFacade)
        => LifeItem = lifeFacade;

    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    public void AddDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.RemoveDecorator(decorator);
    public void Register(Action<ILifeComponent> callback) => LifeItem.Register(callback);
    public void UnRegister(Action<ILifeComponent> callback) => LifeItem.UnRegister(callback);
    public void Notify(ILifeComponent data) => LifeItem.Notify(data);

    public int CurrentLife => LifeItem.CurrentLife;
    public int TotalLife => LifeItem.TotalLife;
    public int Damage => LifeItem.Damage;
    public void TakeDamage(int damage) => LifeItem.TakeDamage(damage);

    #endregion

    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
            => new HeroCard(
                game,
                CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
                FlipFacade.Get(
                    AlterEgoFace.Get((AlterEgoFaceModel)cardModel.Face),
                    HeroFace.Get((HeroFaceModel)cardModel.Back)),
                TapFacade.Get(),
                LifeFacade.Get(((HeroCardModel)cardModel).Life));
}
