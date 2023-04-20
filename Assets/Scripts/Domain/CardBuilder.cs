public sealed class CardBuilder
{
    private readonly IGame Game;
    private string Id;
    private IFace Face;
    private IFace Back;
    private string Location;
    private int Order;
    private string OwnerId;
    public CardBuilder(IGame game, string ownerId)
    {
        Game = game;
        OwnerId = ownerId;
    }
    public CardBuilder WithId(string id)
    {
        Id = id;
        return this;
    }
    public CardBuilder WithFace(IFace face)
    {
        Face = face;
        return this;
    }
    public CardBuilder WithBack(IFace back)
    {
        Back = back;
        return this;
    }
    public CardBuilder WithLocation(string location)
    {
        Location = location;
        return this;
    }
    public CardBuilder WithOrder(int order)
    {
        Order = order;
        return this;
    }
    public ICard Build() => new Card(Game, Id, OwnerId, Location, Order, Face, Back);
}