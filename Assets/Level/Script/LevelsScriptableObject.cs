using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "ScriptableObject/Levels")]

public class LevelsScriptableObject : ScriptableObject
{
    public List<LevelScriptableObject> Levels;
}
