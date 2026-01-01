using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public float AttackSpeed;
    public float ProjectileSpeed;
    public float AttackDamage;
    public int MaxAmmo;
}
