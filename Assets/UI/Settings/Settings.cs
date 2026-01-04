using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider m_masterSlider;
    [SerializeField] private Slider m_musicSlider;
    [SerializeField] private Slider m_sfxSlider;
    [SerializeField] private Button m_closeButton;

    private void Start()
    {
        m_closeButton.onClick.AddListener(() => transform.gameObject.SetActive(false));

        // Set initial slider values from PlayerPrefs
        m_masterSlider.value = PlayerPrefs.GetFloat(AudioManager.MIXER_MASTER_VOLUME, 1.0f);
        m_musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MIXER_MUSIC_VOLUME, 1.0f);
        m_sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.MIXER_SFX_VOLUME, 1.0f);

        m_masterSlider.onValueChanged.AddListener((x) => SetVolume(AudioManager.MIXER_MASTER_VOLUME, x));
        m_musicSlider.onValueChanged.AddListener((x) => SetVolume(AudioManager.MIXER_MUSIC_VOLUME, x));
        m_sfxSlider.onValueChanged.AddListener((x) => SetVolume(AudioManager.MIXER_SFX_VOLUME, x));
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    private void SetVolume(string _channel, float _value)
    {
        PlayerPrefs.SetFloat(_channel, _value);
        AudioManager.Instance?.SetChannelVolume(_channel, _value);
    }
}
