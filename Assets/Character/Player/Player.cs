using UnityEngine;

public class Player : Character
{
    [SerializeField] private CharacterScriptableObject m_characterSO;

    //1 set weapon only for demo, otherwise would instantiate/pickup/swap or whatever required
    [SerializeField] private Weapon m_weapon;

    private void Awake()
    {
        m_hp = new HP(m_characterSO.HP);
        m_movement = new Movement(m_characterSO.Speed);
    }

    private void Start()
    {
        GameUI.Instance.HPUI.Set(m_hp.CurrentHP / m_hp.MaxHp);
        GameUI.Instance.AmmoUI.Init(m_weapon.WeaponData.MaxAmmo);
        GameUI.Instance.AmmoUI.Set(m_weapon.WeaponData.CurrentAmmo);
    }
}
