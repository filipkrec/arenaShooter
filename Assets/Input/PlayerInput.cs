using UnityEngine;
using UnityEngine.InputSystem;

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
        m_input.Enable();
        m_input.Game.Move.performed += OnMove;
        m_input.Game.ShootDirectional.performed += OnShootDirectional;
    }

    private void OnDisable()
    {
        m_input.Game.Move.performed -= OnMove;
        m_input.Game.Disable();
    }

    private void OnMove(InputAction.CallbackContext _context)
    {
        Vector2 moveInput = _context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if(m_input.Game.Move.IsPressed())
        {
            m_player.TryMove(m_input.Game.Move.ReadValue<Vector2>());
        }
    }

    private void OnShootDirectional(InputAction.CallbackContext _context)
    {

    }
}
