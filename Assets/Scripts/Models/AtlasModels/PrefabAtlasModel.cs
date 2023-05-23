using System;
using System.Linq;

using UnityEngine;

[CreateAssetMenu(menuName = "Marvel Champions/Card Prefab Atlas")]
public sealed class PrefabAtlasModel : ScriptableObject
{
    public TypePrefabTuple[] Atlas;

    public GameObject GetPrefab(string selector)
        => Atlas.FirstOrDefault(item => item.Type.Equals(selector, StringComparison.OrdinalIgnoreCase))?.Prefab;
}
[Serializable]
public class TypePrefabTuple
{
    public string Type;
    public GameObject Prefab;
}
