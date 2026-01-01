using UnityEngine;
using UnityEngine.AI;

public class Player : Character
{
    public const string PLAYER_TAG = "Player";

    [SerializeField] private CharacterScriptableObject m_characterSO;
    [SerializeField] private NavMeshAgent m_navMeshAgent;
    [SerializeField] private AudioSource m_audioSource;

    //1 set weapon only for demo, otherwise would instantiate/pickup/swap or whatever required
    [SerializeField] private Weapon m_weapon;

    private void Awake()
    {
        m_hp = new HP(m_characterSO.HP);
        m_movement = new Movement(m_characterSO.Speed);
        m_hp.OnDeath = () => AudioManager.Instance.Play(m_deathSound, m_audioSource);
    }

    private void Start()
    {
        GameUI.Instance.HPUI.Set(m_hp.CurrentHP / m_hp.MaxHp);
        GameUI.Instance.AmmoUI.Init(m_weapon.WeaponData.MaxAmmo);
        GameUI.Instance.AmmoUI.Set(m_weapon.WeaponData.CurrentAmmo);
    }

    public override bool TryMove(Vector2 _direction)
    {
        //top down movement, y = up
        Vector3 move = new Vector3(_direction.x, 0f, _direction.y);
        if (NavMeshUtils.CanReach(transform.position, transform.position + move))
        {
            m_navMeshAgent.Move(m_movement.Move(move));
            return true;
        }

        return false;
    }

    public bool TryShoot()
    {
        return m_weapon.TryShoot(transform.rotation.eulerAngles);
    }

    public bool TryShootDirectional(Vector2 _direction)
    {
        transform.rotation = Quaternion.Euler(_direction);
        return TryShoot();
    }
}
