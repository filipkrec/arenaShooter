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

    private void OnCollisionEnter(Collision _collision)
    {
        //Character since it's a small project with clear goal, could've made IHitable for show but decided to rather just write it down here
        if(_collision.gameObject.TryGetComponent(out Character _character))
        {
            _character.OnHit(m_attackDamage);
        }
    }
}
