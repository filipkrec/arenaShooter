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
        

        //initial game setup
        Time.timeScale = 1f;
        Cursor.visible = true;

        Application.targetFrameRate = 60;
    }

    public void Exit()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
