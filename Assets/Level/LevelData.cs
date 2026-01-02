using System;

public class LevelData
{
    public Player Player { get; private set; }
    public int AliveEnemyCount { get; private set; }

    public Action OnNextLevel;

    public LevelData(Player _player, int _aliveEnemyCount, Action _onNextLevel)
    {
        Player = _player;
        AliveEnemyCount = _aliveEnemyCount;
        OnNextLevel = _onNextLevel;
    }

    public void Start(LevelScriptableObject _level)
    {
        AliveEnemyCount = _level.LevelEnemies.Count;
    }

    public void SetEnemyKilled()
    {
        AliveEnemyCount--;
        if (AliveEnemyCount <= 0)
        {
            OnNextLevel?.Invoke();
        }
    }
}
