using UnityEngine;

public class AmmoPickUp : WorldPickUpBase
{
    [SerializeField] private int m_ammoAmount = 25;

    public override void OnPickUp(Player _player)
    {
        _player.Weapon.WeaponData.UpdateAmmo(m_ammoAmount);
    }
}
