using UnityEngine;

public class WeaponData
{
    public float AttackSpeed { get; private set; }
    public float ProjectileSpeed { get; private set; }
    public float AttackDamage { get; private set; }
    public int MaxAmmo { get; private set; }
    public int CurrentAmmo { get; private set; }

    public WeaponData(float _attackSpeed, float _projectileSpeed, float _attackDamage, int _maxAmmo)
    {
        AttackSpeed = _attackSpeed;
        AttackDamage = _attackDamage;
        ProjectileSpeed = _projectileSpeed;
        MaxAmmo = _maxAmmo;

        CurrentAmmo = _maxAmmo;
    }

    public bool TryShoot()
    {
        if (CurrentAmmo > 0)
        {
            CurrentAmmo--;
            return true;
        }

        return false;
    }

    public void UpdateAmmo(int amount)
    {
        CurrentAmmo = Mathf.Clamp(CurrentAmmo + amount, 0, MaxAmmo);
    }
}