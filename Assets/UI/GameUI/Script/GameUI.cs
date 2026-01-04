using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    //TODO Localization
    public const string LEVEL_TEMPLATE = "Current level : {0}";

    //no sense to couple UI with anything/everything. I might use some sort of event system for a more complex project, singleton will do fine for this one.
    public static GameUI Instance => m_instance;

    private static GameUI m_instance;

    public HPUI HPUI;
    public AmmoUI AmmoUI;
    public Reticle Reticle;

    [SerializeField] private Button m_settingsButton;
    [SerializeField] private Settings m_settings;

    [SerializeField] private TextMeshProUGUI m_currentLevel;

    private void Awake()
    {
        if(m_instance != null)
        {
            Destroy(m_instance.gameObject);
        }

        m_instance = this;
    }

    private void Start()
    {
        m_settingsButton.onClick.AddListener(() => m_settings.gameObject.SetActive(true));
        m_settings.EnableExitToMenu();
    }

    public void SetCurrentLevel(int _level)
    {
        m_currentLevel.text = string.Format(LEVEL_TEMPLATE, _level);
    }
}
