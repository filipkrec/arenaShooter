using UnityEngine;

public class Movement
{
    public float Speed => m_speed;
    private float m_speed;

    public Movement(float _speed)
    {
        m_speed = _speed;
    }

    public Vector3 Move(Vector3 _direction)
    {
        return Time.deltaTime * _direction * m_speed;
    }
}
