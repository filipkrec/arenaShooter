using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "ScriptableObject/Sound")]
public class SoundScriptableObject : ScriptableObject
{
    public AudioClip AudioClip;
    public ESound SoundType;
    public bool CanStack;
    public bool DoRepeat;
}
