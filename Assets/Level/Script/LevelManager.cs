using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public const float OVERFLOW_CHECK_DELAY = 1f;
    public static int s_StartingLevel = 0;

    public int CurrentLevelIndex => m_levels.Levels.IndexOf(m_currentLevel);

    private LevelData m_levelData;
    private LevelScriptableObject m_currentLevel;

    [SerializeField] private LevelsScriptableObject m_levels;
    [SerializeField] private List<Spawner> m_spawners;

    private void Start()
    {
        Player player = GameObject.FindGameObjectsWithTag(Player.PLAYER_TAG)?[0]?.GetComponent<Player>();
        if(player == null)
        {
            Debug.LogError("No player found in scene for LevelManager!");
            return;
        }

        m_levelData = new LevelData(player, 0, StartNextLevel);

        //TODO think about this
        StartLevel(s_StartingLevel);
    }

    private void StartLevel(int _levelIndex)
    {
        m_currentLevel = m_levels.Levels[_levelIndex];
        StartCoroutine(SpawnEnemies());

        m_levelData.Start(m_currentLevel);
        GameUI.Instance.SetCurrentLevel(CurrentLevelIndex + 1);
    }

    private void StartNextLevel()
    {
        if (CurrentLevelIndex + 1 >= m_levels.Levels.Count)
        {
            //TODO win game
            return;
        }

        StartLevel(CurrentLevelIndex + 1);
    }   

    private IEnumerator SpawnEnemies()
    {
        Dictionary<Enemy, int> enemiesToSpawn = new Dictionary<Enemy, int>();
        foreach(LevelEnemiesScriptableObject levelEnemiesScriptableObject in m_currentLevel.LevelEnemies)
        {
            enemiesToSpawn.Add(levelEnemiesScriptableObject.EnemyPrefab, levelEnemiesScriptableObject.Count);
        }

        //spawn random enemies on random spawners until all run out
        while (enemiesToSpawn.Count > 0)
        {
            List<Enemy> enemies = new List<Enemy>(enemiesToSpawn.Keys);
            Enemy enemyToSpawn = enemies[Random.Range(0, enemies.Count)];

            //spawn on random spawner, if not available, find first available, if none available wait and retry
            Spawner spawner = m_spawners[Random.Range(0, m_spawners.Count)];
            if(!spawner.CheckAvailable())
            {
                spawner = m_spawners.FirstOrDefault(s => s.CheckAvailable());
                while(spawner == null)
                {
                    spawner = m_spawners.FirstOrDefault(s => s.CheckAvailable());
                    yield return new WaitForSeconds(OVERFLOW_CHECK_DELAY);
                }
            }

            Enemy enemy = Instantiate(enemyToSpawn, spawner.transform.position, Quaternion.identity);
            enemy.InitEnemy(m_levelData.Player, () => m_levelData.SetEnemyKilled());

            enemiesToSpawn[enemyToSpawn]--;
            if (enemiesToSpawn[enemyToSpawn] <= 0)
            {
                enemiesToSpawn.Remove(enemyToSpawn);
            }
            yield return new WaitForSeconds(m_currentLevel.SpawnInterval);
        }
    }

}
