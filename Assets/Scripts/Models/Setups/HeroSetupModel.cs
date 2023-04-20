using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Hero Setup")]
public sealed class HeroSetupModel : ScriptableObject
{
    public InitialSetupModel InitialSetupModel;
    public InGameSetupModel InGameSetupModel;
    public string[] Zones;
}
