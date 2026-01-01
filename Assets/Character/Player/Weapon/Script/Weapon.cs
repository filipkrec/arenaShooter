using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData WeaponData { get; private set; }

    [SerializeField] private WeaponScriptableObject m_weaponScriptableObject;
    [SerializeField] private AudioSource m_audioSource;

    [SerializeField] private Projectile m_projectilePrefab;
    [SerializeField] private SoundScriptableObject m_shootSound;
    [SerializeField] private Transform m_shootOrigin;

    private float m_shootTimer;

    private void Awake()
    {
        WeaponData = new WeaponData(m_weaponScriptableObject.AttackSpeed, 
            m_weaponScriptableObject.ProjectileSpeed, 
            m_weaponScriptableObject.AttackDamage, 
            m_weaponScriptableObject.MaxAmmo); ;
    }

    private void Update()
    {
        if (m_shootTimer > 0f)
        {
            m_shootTimer -= Time.deltaTime;
        }
    }

    public bool TryShoot(Vector3 _direction)
    {
        if(m_shootTimer <= 0 && WeaponData.TryShoot())
        {
            Projectile projectile = Instantiate(m_projectilePrefab, m_shootOrigin.position, m_shootOrigin.rotation, null);
            projectile.Initialize(WeaponData.ProjectileSpeed, WeaponData.AttackDamage);

            AudioManager.Instance.Play(m_shootSound, m_audioSource);

            m_shootTimer = WeaponData.AttackSpeed;
            return true;
        }

        return false;
    }
}
