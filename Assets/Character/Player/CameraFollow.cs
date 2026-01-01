using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private float m_followSpeed = 2f;
    [SerializeField] private Vector3 m_offset;

    private float m_fixedY;

    private void Awake()
    {
        m_fixedY = transform.position.y;
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(
            m_target.position.x,
            m_fixedY,
            m_target.position.z
        ) + m_offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            m_followSpeed * Time.deltaTime
        );
    }
}
