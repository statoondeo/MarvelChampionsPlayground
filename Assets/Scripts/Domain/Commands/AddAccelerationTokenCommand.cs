using System.Collections;
using System.Linq;

public sealed class AddAccelerationTokenCommand : BaseSingleCommand
{
    private AddAccelerationTokenCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        Game.GetAll(CardTypeSelector.Get(CardType.MainScheme)).ToList()
            .ForEach(item => (item as IAccelerationTokenFacade).AddDecorator(SingleAccelerationTokenDecorator.Get()));
        yield return base.Execute();
    }
    public static ICommand Get(IGame game) => new AddAccelerationTokenCommand(game);
}
