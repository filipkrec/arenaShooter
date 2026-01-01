using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance => m_instance;

    private static AudioManager m_instance;

    private const string MIXER_MASTER_VOLUME = "Master";
    private const string MIXER_MUSIC_VOLUME = "Music";
    private const string MIXER_SFX_VOLUME = "SFX";

    [SerializeField] private AudioMixer m_audioMixer;
    [SerializeField] private AudioSource m_musicSource;
    [SerializeField] private AudioSource m_sfxSource;
    [SerializeField] private AudioMixerGroup m_audioMixerGroupSFX;
    [SerializeField] private AudioMixerGroup m_audioMixerGroupMusic;

    private float m_masterVolume;
    private float m_musicVolume;
    private float m_SFXVolume;

    private HashSet<ActiveSound> m_activeNonStackingSounds = new HashSet<ActiveSound>();

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(m_instance);
        }

        m_instance = this;
    }

    public void Play(SoundScriptableObject _sound, AudioSource _source = null)
    {
        if (_source == null)
        {
            if (_sound.SoundType == ESound.MUSIC)
            {
                PlaySoundOnSource(_sound, m_musicSource);
            }
            else if (_sound.SoundType == ESound.SFX)
            {
                PlaySoundOnSource(_sound, m_sfxSource);
            }
        }
        else
        {
            PlaySoundOnSource(_sound, _source);
        }
    }

    private void PlaySoundOnSource(SoundScriptableObject _sound, AudioSource _source)
    {
        if (!_sound.CanStack)
        {
            //if cant stack, add to hashset and remove after sound duration, if already in, ignore
            ActiveSound activeSound = new ActiveSound { Source = _source, Sound = _sound };
            if (!m_activeNonStackingSounds.Contains(activeSound))
            {
                m_activeNonStackingSounds.Add(activeSound);
                DOVirtual.DelayedCall(_sound.AudioClip.length, () => m_activeNonStackingSounds.Remove(activeSound), true);
            }
            else
            {
                return;
            }
        }

        _source.outputAudioMixerGroup = _sound.SoundType == ESound.SFX ? m_audioMixerGroupSFX : m_audioMixerGroupMusic;
        _source.clip = _sound.AudioClip;
        _source.loop = _sound.DoRepeat;
        _source.volume = _sound.VolumeMultiplier;

        _source.Play();
    }
}

public struct ActiveSound
{
    public AudioSource Source;
    public SoundScriptableObject Sound;
}

