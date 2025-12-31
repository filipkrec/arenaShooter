using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float AttackSpeed => m_weaponData.AttackSpeed;

    private WeaponData m_weaponData;

    [SerializeField] private Projectile m_projectilePrefab;
    [SerializeField] private SoundScriptableObject m_shootSound;
    [SerializeField] private Transform m_shootOrigin;
    
    public bool TryShoot(Vector3 _direction)
    {
        if(m_weaponData.TryShoot())
        {
            Projectile projectile = Instantiate(m_projectilePrefab, m_shootOrigin.position, m_shootOrigin.rotation, null);
            projectile.Initialize(m_weaponData.ProjectileSpeed, m_weaponData.AttackDamage);

            return true;
        }

        return false;
    }
}
