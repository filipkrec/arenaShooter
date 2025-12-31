using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Character : MonoBehaviour
{
    [SerializeField] protected SoundScriptableObject m_deathSound;
    protected HP Hp;
    protected Movement Movement;
    
    protected virtual void OnHit(GameObject _go)
    {

    }

    protected virtual bool TryMove(Vector3 _direction) { return false; }

    private void OnCollisionEnter(Collision _collision)
    {
        OnHit(_collision.gameObject);
    }
}
