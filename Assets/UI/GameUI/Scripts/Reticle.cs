using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    [SerializeField] private Image m_reticleImage;

    public void Show(bool _doShow)
    {
        m_reticleImage.gameObject.SetActive(_doShow);
    }

    public void UpdatePosition(Vector2 _position)
    {
        if (m_reticleImage.gameObject.activeSelf)
        {
            m_reticleImage.transform.position = _position;
        }
    }
}