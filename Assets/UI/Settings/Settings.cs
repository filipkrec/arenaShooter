using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Button m_closeButton;

    private void Start()
    {
        m_closeButton.onClick.AddListener(() => transform.gameObject.SetActive(false));
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
