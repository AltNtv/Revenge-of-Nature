using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputHandler : MonoBehaviour
{
    private InputMap m_inputMap;
    private InputMap.PlayerInputActions m_playerInputActions;

    private float m_movementHorizontalInput;
    private float m_movementVerticalInput;
    private float m_rotationDeltaHorizontalInput;
    private float m_rotationDeltaVerticalInput;

    [SerializeField] private float mouseSensitivityX = 1f;
    [SerializeField] private float mouseSensitivityY = 1f;



    private void Awake()
    {
        m_inputMap = new InputMap();
        m_playerInputActions = m_inputMap.PlayerInput;
    }

    private void OnEnable()
    {
        m_inputMap.Enable();

        m_playerInputActions.MovementHorizontal.started += OnMovementChangedHorizontal;
        m_playerInputActions.MovementHorizontal.performed += OnMovementChangedHorizontal;
        m_playerInputActions.MovementHorizontal.canceled += OnMovementChangedHorizontal;

        m_playerInputActions.MovementVertical.started += OnMovementChangedVertical;
        m_playerInputActions.MovementVertical.performed += OnMovementChangedVertical;
        m_playerInputActions.MovementVertical.canceled += OnMovementChangedVertical;

        m_playerInputActions.RotationDeltaHorizontal.performed += OnRotationDeltaHorizontalChanged;
        m_playerInputActions.RotationDeltaVertical.performed += OnRotationDeltaVerticalChanged;
    }

    private void OnDisable()
    {
        m_playerInputActions.MovementHorizontal.started -= OnMovementChangedHorizontal;
        m_playerInputActions.MovementHorizontal.performed -= OnMovementChangedHorizontal;
        m_playerInputActions.MovementHorizontal.canceled -= OnMovementChangedHorizontal;

        m_playerInputActions.MovementVertical.started -= OnMovementChangedVertical;
        m_playerInputActions.MovementVertical.performed -= OnMovementChangedVertical;
        m_playerInputActions.MovementVertical.canceled -= OnMovementChangedVertical;

        m_playerInputActions.RotationDeltaHorizontal.performed -= OnRotationDeltaHorizontalChanged;
        m_playerInputActions.RotationDeltaVertical.performed -= OnRotationDeltaVerticalChanged;

        m_inputMap.Disable();
    }

    private void OnMovementChangedHorizontal(InputAction.CallbackContext context)
    {
        m_movementHorizontalInput = context.ReadValue<float>();
    }
    private void OnMovementChangedVertical(InputAction.CallbackContext context)
    {
        m_movementVerticalInput = context.ReadValue<float>();
    }
    private void OnRotationDeltaHorizontalChanged(InputAction.CallbackContext context)
    {
        m_rotationDeltaHorizontalInput = context.ReadValue<float>();
    }
    private void OnRotationDeltaVerticalChanged(InputAction.CallbackContext context)
    {
        m_rotationDeltaVerticalInput = context.ReadValue<float>();
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 direction = new Vector3(m_movementHorizontalInput, 0f, m_movementVerticalInput);
        return Vector3.ClampMagnitude(direction, 1f);
    }
}
