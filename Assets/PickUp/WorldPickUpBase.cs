using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class WorldPickUpBase : MonoBehaviour, IPickUp
{
    [SerializeField] private float m_rotationSpeed = 60f;

    public virtual void OnPickUp(Player _player)
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag(Player.PLAYER_TAG))
        {
            OnPickUp(_other.GetComponent<Player>());
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * m_rotationSpeed);
    }
}
