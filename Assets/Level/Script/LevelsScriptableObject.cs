using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "ScriptableObject/Levels")]

public class LevelsScriptableObject : ScriptableObject
{
    public LevelsCountScriptableObject LevelsCount;
    public List<LevelScriptableObject> Levels;

#if UNITY_EDITOR
    public void OnValidate()
    {
        if (LevelsCount != null)
        {
            LevelsCount.Value = Levels.Count;
            EditorUtility.SetDirty(LevelsCount);
            AssetDatabase.SaveAssets();
        }
    }
#endif

}
