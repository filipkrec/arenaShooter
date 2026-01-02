using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObject/Level")]
public class LevelScriptableObject : ScriptableObject
{
    public List<LevelEnemiesScriptableObject> LevelEnemies;
    public float SpawnInterval;
}
