using UnityEngine;

[CreateAssetMenu(fileName = "LevelEnemies", menuName = "ScriptableObject/LevelEnemies")]
public class LevelEnemiesScriptableObject : ScriptableObject
{
    public Enemy EnemyPrefab;
    public int Count;
}
