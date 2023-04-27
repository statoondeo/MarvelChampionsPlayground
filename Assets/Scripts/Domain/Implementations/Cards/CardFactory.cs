public sealed class CardFactory
{
    public ICard Create(IGame game, string id, string ownerId, CardModel cardModel)
    {
        if (cardModel is AllyCardModel allyCardModel) return BasicAllyCard.Get(game, id, ownerId, allyCardModel);
        if (cardModel is AttachmentCardModel attachmentCardModel) return BasicAttachmentCard.Get(game, id, ownerId, attachmentCardModel);
        if (cardModel is EnvironmentCardModel environmentCardModel) return BasicEnvironmentCard.Get(game, id, ownerId, environmentCardModel);
        if (cardModel is EventCardModel eventCardModel) return BasicEventCard.Get(game, id, ownerId, eventCardModel);
        if (cardModel is HeroCardModel heroCardModel) return BasicHeroCard.Get(game, id, ownerId, heroCardModel);
        if (cardModel is MainSchemeCardModel mainSchemeCardModel) return BasicMainSchemeCard.Get(game, id, ownerId, mainSchemeCardModel);
        if (cardModel is MinionCardModel minionCardModel) return BasicMinionCard.Get(game, id, ownerId, minionCardModel);
        if (cardModel is ObligationCardModel obligationCardModel) return BasicObligationCard.Get(game, id, ownerId, obligationCardModel);
        if (cardModel is ResourceCardModel resourceCardModel) return BasicResourceCard.Get(game, id, ownerId, resourceCardModel);
        if (cardModel is SideSchemeCardModel sideSchemeCardModel) return BasicSideSchemeCard.Get(game, id, ownerId, sideSchemeCardModel);
        if (cardModel is SupportCardModel supportCardModel) return BasicSupportCard.Get(game, id, ownerId, supportCardModel);
        if (cardModel is TreacheryCardModel treacheryCardModel) return BasicTreacheryCard.Get(game, id, ownerId, treacheryCardModel);
        if (cardModel is UpgradeCardModel upgradeCardModel) return BasicUpgradeCard.Get(game, id, ownerId, upgradeCardModel);
        if (cardModel is VillainCardModel villainCardModel) return BasicVillainCard.Get(game, id, ownerId, villainCardModel);
        return null;
    }
}
