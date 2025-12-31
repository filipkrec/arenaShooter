using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_maxAmmo;
    [SerializeField] private TextMeshProUGUI m_currentAmmo;

    public void Init(int _maxAmmo)
    {
        m_maxAmmo.text = _maxAmmo.ToString();
    }

    public void Set(int _currentAmmo)
    {
        //TODO animation?
        m_currentAmmo.text = _currentAmmo.ToString();
    }
}
