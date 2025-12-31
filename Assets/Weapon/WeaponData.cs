using UnityEngine;

public class WeaponData
{
    public float AttackSpeed => m_attackSpeed;
    public float ProjectileSpeed => m_projectileSpeed;
    public float AttackDamage => m_attackDamage;
    public int MaxAmmo => m_maxAmmo;
    public int CurrentAmmo => m_currentAmmo;

    private float m_attackSpeed;
    private float m_projectileSpeed;
    private float m_attackDamage;
    private int m_maxAmmo;
    private int m_currentAmmo;

    public bool TryShoot()
    {
        if(m_currentAmmo > 0)
        {
            m_currentAmmo--;
            return true;
        }

        return false;
    }

    public void UpdateAmmo(int _amount)
    {
        m_currentAmmo = Mathf.Clamp(m_currentAmmo + _amount, 0, m_maxAmmo);
    }
}
