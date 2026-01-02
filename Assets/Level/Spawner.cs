using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float m_availabilityRadius = 1f;

    public bool CheckAvailable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_availabilityRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                return false;
            }
        }
        return true;
    }
}
