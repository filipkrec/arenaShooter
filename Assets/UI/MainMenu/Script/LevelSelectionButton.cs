using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    public Button Button;
    [SerializeField] private TextMeshProUGUI m_text;

    public void SetText(string _text)
    {
        m_text.text = _text;
    }
}
