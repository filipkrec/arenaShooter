using UnityEngine;
using UnityEngine.AI;

public class Player : Character
{
    public const string PLAYER_TAG = "Player";

    public Weapon Weapon => m_weapon;
    public HP HP => m_hp;

    [SerializeField] private CharacterScriptableObject m_characterSO;
    [SerializeField] private NavMeshAgent m_navMeshAgent;
    [SerializeField] private AudioSource m_audioSource;

    //1 set weapon only for demo, otherwise would instantiate/pickup/swap or whatever required
    [SerializeField] private Weapon m_weapon;


    private void Awake()
    {
        Init(m_characterSO);
        m_hp.OnDeath = () => AudioManager.Instance.Play(m_deathSound, m_audioSource);
    }

    private void Start()
    {
        GameUI.Instance.HPUI.Set(m_hp.CurrentHP / m_hp.MaxHp);
        GameUI.Instance.AmmoUI.Init(m_weapon.WeaponData.MaxAmmo);
        GameUI.Instance.AmmoUI.Set(m_weapon.WeaponData.CurrentAmmo);

        m_hp.OnUpdateHP += () => GameUI.Instance.HPUI.Set(m_hp.CurrentHP / m_hp.MaxHp);
        m_weapon.WeaponData.OnUpdateAmmo += () => GameUI.Instance.AmmoUI.Set(m_weapon.WeaponData.CurrentAmmo);
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
        RotateToDirection(new Vector3(_direction.x, 0f, _direction.y));
        return TryShoot();
    }

    public void RotateToDirection(Vector3 _direction)
    {
        Vector3 targetRotation = Quaternion.LookRotation(_direction, Vector3.up).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, targetRotation.y, 0f);
    }
}
