using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    const float REPATH_DELAY = 0.15f;
    
    private Player m_targetPlayer;
    private float m_damage;
    [SerializeField] private NavMeshAgent m_agent;
    [SerializeField] private EnemyScriptableObject m_enemySO;
    [SerializeField] private AudioSource m_audioSource;

    /// <summary>
    /// Call on spawn. Initialize enemy with target player.
    /// </summary>
    /// <param name="_targetPlayer"></param>
    public void InitEnemy(Player _targetPlayer)
    {
        m_targetPlayer = _targetPlayer;

        Init(m_enemySO);
        TryMove(default);

        StartCoroutine(RepathCoroutine());
    }

    protected override void Init(CharacterScriptableObject _characterSO)
    {
        base.Init(_characterSO);

        if (_characterSO is EnemyScriptableObject enemySO)
        {
            m_damage = enemySO.Damage;
            m_hp.OnDeath = () =>
            {
                AudioManager.Instance.Play(m_deathSound, m_audioSource);
                Destroy(gameObject);
            };
        }
    }

    private IEnumerator RepathCoroutine()
    {
        while(true)
        {
            TryMove(default);
            yield return new WaitForSeconds(REPATH_DELAY);
        }
    }

    /// <summary>
    /// Move towards player, Ignore direction since agent calculates it internally
    /// </summary>
    /// <param name="_direction"></param>
    public override bool TryMove(Vector2 _direction)
    {
        if (m_targetPlayer != null)
        {
            m_agent.SetDestination(m_targetPlayer.transform.position);
            return true;
        }

        return false;
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.CompareTag(Player.PLAYER_TAG))
        {
            _collision.gameObject.GetComponent<Player>().OnHit(m_damage);
            Destroy(gameObject);
        }
    }
}
