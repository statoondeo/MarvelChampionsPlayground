public sealed class CardFactory
{
    public ICard Create(IGame game, string id, string ownerId, CardModel cardModel)
    {
        if (cardModel is AllyCardModel allyCardModel) return AllyCard.Get(game, id, ownerId, allyCardModel);
        if (cardModel is AttachmentCardModel attachmentCardModel) return AttachmentCard.Get(game, id, ownerId, attachmentCardModel);
        if (cardModel is EnvironmentCardModel environmentCardModel) return EnvironmentCard.Get(game, id, ownerId, environmentCardModel);
        if (cardModel is EventCardModel eventCardModel) return EventCard.Get(game, id, ownerId, eventCardModel);
        if (cardModel is HeroCardModel heroCardModel) return HeroCard.Get(game, id, ownerId, heroCardModel);
        if (cardModel is MainSchemeCardModel mainSchemeCardModel) return SingleMainSchemeCard.Get(game, id, ownerId, mainSchemeCardModel);
        if (cardModel is MinionCardModel minionCardModel) return MinionCard.Get(game, id, ownerId, minionCardModel);
        if (cardModel is ObligationCardModel obligationCardModel) return ObligationCard.Get(game, id, ownerId, obligationCardModel);
        if (cardModel is ResourceCardModel resourceCardModel) return ResourceCard.Get(game, id, ownerId, resourceCardModel);
        if (cardModel is SideSchemeCardModel sideSchemeCardModel) return SideSchemeCard.Get(game, id, ownerId, sideSchemeCardModel);
        if (cardModel is SupportCardModel supportCardModel) return SupportCard.Get(game, id, ownerId, supportCardModel);
        if (cardModel is TreacheryCardModel treacheryCardModel) return TreacheryCard.Get(game, id, ownerId, treacheryCardModel);
        if (cardModel is UpgradeCardModel upgradeCardModel) return UpgradeCard.Get(game, id, ownerId, upgradeCardModel);
        if (cardModel is VillainCardModel villainCardModel) return VillainCard.Get(game, id, ownerId, villainCardModel);
        return null;
    }
}
