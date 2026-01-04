using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    const float REPATH_DELAY = 0.15f;
    const float DROP_SPAWN_HEIGHT = 0.5f;

    private Player m_targetPlayer;
    private float m_damage;
    [SerializeField] private NavMeshAgent m_agent;
    [SerializeField] private EnemyScriptableObject m_enemySO;
    [SerializeField] private AudioSource m_audioSource;

    [SerializeField] private PickUpsScriptableObject m_pickUpsScriptableObjects;

    private Action m_notifyOnDeath;

    /// <summary>
    /// Call on spawn. Initialize enemy with target player.
    /// </summary>
    /// <param name="_targetPlayer"></param>
    public void InitEnemy(Player _targetPlayer, Action _notifyOnDeath)
    {
        m_targetPlayer = _targetPlayer;
        m_notifyOnDeath = _notifyOnDeath;

        Init(m_enemySO);
        TryMove(default);

        StartCoroutine(RepathCoroutine());
    }

    protected override void Init(CharacterScriptableObject _characterSO)
    {
        base.Init(_characterSO);

        m_agent.speed = m_movement.Speed;

        if (_characterSO is EnemyScriptableObject enemySO)
        {
            m_damage = enemySO.Damage;
            m_hp.OnDeath = () =>
            {
                m_notifyOnDeath?.Invoke();
                AudioManager.Instance.Play(m_deathSound);
                RollDrop();
                Destroy(gameObject);
            };
        }
    }

    private IEnumerator RepathCoroutine()
    {
        while (true)
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

            m_hp.UpdateHP(-m_hp.CurrentHP);
        }
    }

    private void RollDrop()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= m_pickUpsScriptableObjects.DropChance)
        {
            WorldPickUpBase dropPrefab = m_pickUpsScriptableObjects.PickUpPrefabs[UnityEngine.Random.Range(0, m_pickUpsScriptableObjects.PickUpPrefabs.Count)];
            WorldPickUpBase drop = Instantiate(dropPrefab, null);
            drop.transform.position = new Vector3(transform.position.x, DROP_SPAWN_HEIGHT, transform.position.z);
        }
    }
}
