using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int s_StartingLevel = 0;

    public int CurrentLevelIndex => m_levels.IndexOf(m_currentLevel);

    private LevelData m_levelData;
    private LevelScriptableObject m_currentLevel;

    [SerializeField] private List<LevelScriptableObject> m_levels;
    [SerializeField] private List<Transform> m_spawners;

    private void Start()
    {
        Player player = GameObject.FindGameObjectsWithTag(Player.PLAYER_TAG)?[0]?.GetComponent<Player>();
        if(player == null)
        {
            Debug.LogError("No player found in scene for LevelManager!");
            return;
        }


        m_levelData = new LevelData(player, 0, StartNextLevel);
    }

    private void StartNextLevel()
    {
        if (CurrentLevelIndex + 1 >= m_levels.Count)
        {
            //TODO win game
            return;
        }

        m_currentLevel = m_levels[CurrentLevelIndex + 1];
        SpawnEnemies();

        m_levelData.Start(m_currentLevel);
    }   

    //TODO
    private IEnumerator SpawnEnemies()
    {
        yield return null;
    }

}
