using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField] private float m_updateDelay = 0.3f;

    [SerializeField] private Image m_maxHpImage;
    [SerializeField] private Image m_currentHpImage;

    private Tween m_hpTween;

    public void Set(float _percentage)
    {
        if(m_hpTween != null)
        {
            m_hpTween.Kill();
        }

        m_hpTween = m_currentHpImage.DOFillAmount(_percentage, m_updateDelay);
    }
}
