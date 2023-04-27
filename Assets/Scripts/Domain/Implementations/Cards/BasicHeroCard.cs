public sealed class BasicHeroCard : BaseCard, IHeroCard
{
    #region ILife

    private readonly ILife LifeBrick;
    public int Life => LifeBrick.Life;

    #endregion

    private BasicHeroCard(
            IGame game,
            string cardId,
            string id,
            string ownerId,
            IFace face,
            IFace back,
            ILife lifeComponent)
        : base(
            game,
            cardId,
            id,
            ownerId,
            face,
            back) 
        => LifeBrick = lifeComponent;

    public static ICard Get(IGame game,
            string id,
            string ownerId,
            HeroCardModel cardModel) 
        => new BasicHeroCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            AlterEgoFacade.Get((AlterEgoFaceModel)cardModel.Face),
            BasicHeroFace.Get((HeroFaceModel)cardModel.Back),
            LifeComponent.Get(cardModel.Life));
}