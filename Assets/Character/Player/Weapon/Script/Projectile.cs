using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    private Movement Movement;
    private float m_attackDamage;

    public void Initialize(float _movementSpeed, float _damage)
    {
        Movement = new Movement(_movementSpeed);
        m_attackDamage = _damage;
    }

    private void Update()
    {
        transform.position += Movement.Move(transform.forward);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.CompareTag(Player.PLAYER_TAG)) return;

        if (_other.gameObject.TryGetComponent(out Character _character))
        {
            _character.OnHit(m_attackDamage);
        }

        Destroy(gameObject);
    }
}
