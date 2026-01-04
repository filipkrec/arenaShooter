using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionMenu : MonoBehaviour
{
    [SerializeField] private LevelsScriptableObject m_levels;
    [SerializeField] private Button m_exitButton;
    [SerializeField] private LevelSelectionButton m_levelSelectionButtonPrefab;
    [SerializeField] private Transform m_buttonParent;

    private void Awake()
    {
        int index = 0;
        foreach (LevelScriptableObject level in m_levels.Levels)
        {
            int currentIndex = index; //cache for button action

            LevelSelectionButton button = Instantiate(m_levelSelectionButtonPrefab, m_buttonParent);
            button.Button.onClick.AddListener(() => OnSelectLevel(currentIndex));
            button.SetText((index + 1).ToString()); //levels go from 1 onwards
            button.transform.SetAsLastSibling();

            index++;
        }
    }

    private void Start()
    {
        m_exitButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

    private void OnSelectLevel(int _level)
    {
        LevelManager.s_StartingLevel = _level;
        SceneLoader.LoadScene(SceneLoader.SCENE_GAME);
    }
}
