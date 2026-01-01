using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerInputActions m_input;
    [SerializeField] private Player m_player;

    private void Awake()
    {
        m_input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        m_input.Game.Enable();
    }

    private void OnDisable()
    {
        m_input.Game.Disable();
    }

    private void Update()
    {
        if (m_input.Game.Move.IsPressed())
        {
            m_player.TryMove(m_input.Game.Move.ReadValue<Vector2>());
        }
        if (m_input.Game.ShootDirectional.IsPressed())
        {
            m_player.TryShootDirectional(m_input.Game.ShootDirectional.ReadValue<Vector2>());
        }
        if (m_input.Game.Shoot.IsPressed())
        {
            m_player.TryShoot();
        }
    }
}
