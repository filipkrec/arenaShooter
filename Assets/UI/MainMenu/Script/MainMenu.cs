using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SoundScriptableObject m_mainMenuBGM;

    [SerializeField] private Button m_levelSelectionButton;
    [SerializeField] private Button m_settingsButton;
    [SerializeField] private Button m_exitButton;

    [SerializeField] private LevelSelectionMenu m_levelSelectionMenu;
    [SerializeField] private GameObject m_settings;

    private void Start()
    {
        m_levelSelectionButton.onClick.AddListener(() => m_levelSelectionMenu.gameObject.SetActive(true));
        m_settingsButton.onClick.AddListener(() => m_settings.gameObject.SetActive(true));
        m_exitButton.onClick.AddListener(Exit);

        Time.timeScale = 1f;
        Cursor.visible = true;
    }

    public void Exit()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
