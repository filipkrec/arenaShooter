using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUps", menuName = "ScriptableObject/PickUps")]
public class PickUpsScriptableObject : ScriptableObject
{
    public float DropChance = 0.15f;
    public List<WorldPickUpBase> PickUpPrefabs;
}
