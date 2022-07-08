using UnityEngine;
using UnityEngine.InputSystem;


// If player presses any button inside the game, it should be added to the InputMap which is located in Resources/Input
// Then should to subscribe in OnEnable() on events which are in need. Don't forget to unsibscribe in OnDisable() method!

internal sealed class PlayerInputHandler : MonoBehaviour
{
    [Tooltip("Invert mouse X Axis")]
    [SerializeField] private bool m_invertXAxis = false;

    [Tooltip("Invert mouse Y Axis")]
    [SerializeField] private bool m_invertYAxis = false;

    [Tooltip("Mouse Sensitivity X Axis")]
    [SerializeField] private float m_mouseSensitivityX = 1f;

    [Tooltip("Mouse Sensitivity Y Axis")]
    [SerializeField] private float m_mouseSensitivityY = 1f;

    private InputMap m_inputMap;
    private InputMap.PlayerInputActions m_playerInputActions;

    private float m_movementHorizontalInput = 0f;
    private float m_movementVerticalInput = 0f;
    private float m_rotationDeltaHorizontalInput = 0f;
    private float m_rotationDeltaVerticalInput = 0f;
    private float m_rotationHorizontal = 0f;
    private float m_rotationVertical = 0f;


    private void Awake()
    {
        m_inputMap = new InputMap();
        m_playerInputActions = m_inputMap.PlayerInput;
    }

    // Subscribing on events
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
    // Unsubscribing from events
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

        // Multiply input value by mouse sensitivity
        m_rotationHorizontal += m_rotationDeltaHorizontalInput * m_mouseSensitivityX;

        // Invert rotation if needed
        if (m_invertXAxis)
        {
            m_rotationHorizontal *= -1f;
        }
    }

    private void OnRotationDeltaVerticalChanged(InputAction.CallbackContext context)
    {
        m_rotationDeltaVerticalInput = context.ReadValue<float>();

        // Multiply input value by mouse sensitivity
        m_rotationVertical += m_rotationDeltaVerticalInput * m_mouseSensitivityY;

        // Invert rotation if needed
        if (m_invertYAxis)
        {
            m_rotationVertical *= -1f;
        }

        // Limit vertical rotation
        m_rotationVertical = Mathf.Clamp(m_rotationVertical, -89f, 89f);
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 direction = new Vector3(m_movementHorizontalInput, 0f, m_movementVerticalInput);

        // Limit direction magnitude to 1f
        return Vector3.ClampMagnitude(direction, 1f);
    }

    public float GetHorizontalLookAxis()
    {
        return m_rotationHorizontal;
    }

    public float GetVerticalLookAxis()
    {
        return m_rotationVertical;
    }
}
