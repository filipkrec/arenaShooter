using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    //no sense to couple UI with anything/everything. I might use some sort of event system for a more complex project, singleton will do fine for this one.
    public static GameUI Instance => m_instance;

    private static GameUI m_instance;

    public HPUI HPUI;
    public AmmoUI AmmoUI;
    public Reticle Reticle;

    [SerializeField] private Button m_settingsButton;
    [SerializeField] private Settings m_settings;

    [SerializeField] private TextMeshProUGUI m_currentLevel;

    [Header("Victory")]
    [SerializeField] private GameObject m_victoryScreen;
    [SerializeField] private Button m_exitButtonVictory;

    [Header("Defeat")]
    [SerializeField] private GameObject m_defeatScreen;
    [SerializeField] private Button m_exitButtonDefeat;

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(m_instance.gameObject);
        }

        m_instance = this;
    }

    private void Start()
    {
        m_settings.EnableExitToMenu();
        m_settings.OnCloseSettings = () => Reticle.Show(true);
        m_settingsButton.onClick.AddListener(ShowSettings);
        Reticle.Show(true);

        if (!PlayerInput.s_input.Game.enabled)
        {
            PlayerInput.s_input.Game.Enable();
        }

        PlayerInput.s_input.Game.Escape.performed += ToggleSettings;
    }

    public void SetCurrentLevel(int _level)
    {
        m_currentLevel.text = _level.ToString();
    }

    //TODO unite victory defeat?
    public void ShowVictoryScreen()
    {
        Time.timeScale = 0f;

        m_victoryScreen.gameObject.SetActive(true);
        m_exitButtonVictory.onClick.AddListener(() => SceneLoader.LoadScene(SceneLoader.SCENE_MENU));

        Reticle.Show(false);
    }

    public void ShowDefeatScreen()
    {
        Time.timeScale = 0f;

        m_defeatScreen.gameObject.SetActive(true);
        m_exitButtonDefeat.onClick.AddListener(() => SceneLoader.LoadScene(SceneLoader.SCENE_MENU));

        Reticle.Show(false);
    }

    private void ShowSettings()
    {
        m_settings.gameObject.SetActive(true);
        Reticle.Show(false);
    }

    private void ToggleSettings(InputAction.CallbackContext _context)
    {
        m_settings.gameObject.SetActive(!m_settings.gameObject.activeSelf);
    }

    private void OnDestroy()
    {
        PlayerInput.s_input.Game.Escape.performed -= ToggleSettings;
    }
}
