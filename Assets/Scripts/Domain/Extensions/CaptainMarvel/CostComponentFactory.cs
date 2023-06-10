public sealed class CostComponentFactory
{
    public ICostComponent Create(FaceType faceType, int cost, string name) 
        => name switch
        {
            "CRISIS_INTERDICTION" => CrisisInterdictionCostComponent.Get(cost),
            _ => faceType switch
            {
                FaceType.Event => InstantCostComponent.Get(cost),
                _ => PermanentCostComponent.Get(cost),
            }
        };
}