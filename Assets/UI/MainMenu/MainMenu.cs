using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void SetStartingLevel(int _level)
    {
        LevelManager.s_StartingLevel = _level;
    }
}
