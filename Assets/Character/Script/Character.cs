using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Character : MonoBehaviour
{
    [SerializeField] protected SoundScriptableObject m_deathSound;
    protected HP m_hp;
    protected Movement m_movement;

    protected virtual void Init(CharacterScriptableObject _characterSO)
    {
        m_hp = new HP(_characterSO.HP);
        m_movement = new Movement(_characterSO.Speed);
    }

    public virtual void OnHit(float _damage)
    {
        m_hp.UpdateHP(-_damage);
    }

    public virtual bool TryMove(Vector2 _direction) 
    { 
        return false; 
    }
}
