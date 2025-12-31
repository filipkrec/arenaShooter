using UnityEngine;

public class Player : Character
{
    [SerializeField] private CharacterScriptableObject m_characterSO;

    //1 set weapon only for demo, otherwise would instantiate/pickup/swap or whatever required
    [SerializeField] private Weapon Weapon;

    private void Start()
    {
        m_hp = new HP(m_characterSO.HP);
        m_movement = new Movement(m_characterSO.Speed);
    }
}
