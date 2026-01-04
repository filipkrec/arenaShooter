using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance => m_instance;

    private static AudioManager m_instance;

    public const string MIXER_MASTER_VOLUME = "Master";
    public const string MIXER_MUSIC_VOLUME = "Music";
    public const string MIXER_SFX_VOLUME = "SFX";

    [SerializeField] private SoundScriptableObject m_bgm;
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

        m_masterVolume = PlayerPrefs.GetFloat(MIXER_MASTER_VOLUME, 1.0f);
        m_musicVolume = PlayerPrefs.GetFloat(MIXER_MUSIC_VOLUME, 1.0f);
        m_SFXVolume = PlayerPrefs.GetFloat(MIXER_SFX_VOLUME, 1.0f);

        SetChannelVolume(MIXER_MASTER_VOLUME, m_masterVolume);
        SetChannelVolume(MIXER_MUSIC_VOLUME, m_musicVolume);
        SetChannelVolume(MIXER_SFX_VOLUME, m_SFXVolume);

        m_instance = this;
    }

    private void Start()
    {
        Play(m_bgm);
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

    public void SetChannelVolume(string _channel, float _volume)
    {
        // Set the AudioMixer values (linear [0,1] mapped to dB), boilerplate formula
        m_audioMixer.SetFloat(_channel, Mathf.Log10(_volume <= 0 ? 0.0001f : _volume) * 20f);
    }

}

public struct ActiveSound
{
    public AudioSource Source;
    public SoundScriptableObject Sound;
}

