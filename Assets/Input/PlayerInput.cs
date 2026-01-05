using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static  PlayerInputActions s_input = new PlayerInputActions();

    [SerializeField] private Player m_player;

    private InputDevice m_currentDevice;
    private Camera m_main;
    private Plane m_playerPlane;

    private void Awake()
    {
        m_main = Camera.main;
        s_input = new PlayerInputActions();
        m_playerPlane = new Plane(Vector3.up, m_player.transform.position);
    }

    private void SetDevice(InputAction.CallbackContext _context)
    {
        m_currentDevice = _context.control.device;
    }

    private void OnEnable()
    {
        if (!s_input.Game.enabled)
        {
            s_input.Game.Enable();
        }

        s_input.Game.Move.performed += SetDevice;
        s_input.Game.Shoot.performed += SetDevice;
        s_input.Game.ShootDirectional.performed += SetDevice;
    }

    private void OnDisable()
    {
        s_input.Game.Disable();
        s_input.Game.Move.performed -= SetDevice;
        s_input.Game.Shoot.performed -= SetDevice;
        s_input.Game.ShootDirectional.performed -= SetDevice;
    }

    private void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) return;

        if (s_input.Game.Move.IsPressed())
        {
            m_player.TryMove(s_input.Game.Move.ReadValue<Vector2>());
        }

        //rotate to stick direction and shoot otherwise
        if (s_input.Game.ShootDirectional.IsPressed())
        {
            Vector2 direction = s_input.Game.ShootDirectional.ReadValue<Vector2>();
            m_player.TryShootDirectional(direction);
            
            float offset = GameUI.Instance.Reticle.AimOffset;

            GameUI.Instance.Reticle.UpdatePosition(direction * offset);
        }

        if (!IsPointerOverUI() && s_input.Game.Shoot.IsPressed())
        {
            m_player.TryShoot();
        }

        //rotate to mouse on keyboard&mouse
        if (m_currentDevice is Keyboard || m_currentDevice is Mouse)
        {
            Ray ray = m_main.ScreenPointToRay(Input.mousePosition);

            if (m_playerPlane.Raycast(ray, out float distance))
            {
                Vector3 worldPoint = ray.GetPoint(distance);
                Vector3 direction = (worldPoint - m_player.transform.position).normalized;
                m_player.RotateToDirection(direction);
            }

            GameUI.Instance.Reticle.UpdatePosition(Input.mousePosition);
        }
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current != null &&
               EventSystem.current.IsPointerOverGameObject();
    }
}
