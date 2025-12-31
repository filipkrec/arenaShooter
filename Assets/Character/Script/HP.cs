using System;
using UnityEngine;

public class HP
{
    public float MaxHp => m_maxHP;
    public float CurrentHP => m_currentHP;

    private float m_maxHP;
    private float m_currentHP;

    public Action OnUpdateHP;
    public Action OnDeath;

    public HP(float _maxHP)
    {
        m_maxHP = _maxHP;
        m_currentHP = m_maxHP;
    }

    public void UpdateHP(float _change)
    {
        m_currentHP += Mathf.Clamp(_change, 0f, m_maxHP);

        if(Mathf.Approximately(m_currentHP,0f))
        {
            OnDeath?.Invoke();
        }
    }
}
