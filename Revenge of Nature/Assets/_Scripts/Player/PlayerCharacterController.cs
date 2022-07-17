using UnityEngine;


[SelectionBase]
[RequireComponent(typeof(PlayerInputHandler), typeof(CharacterController))]
internal sealed class PlayerCharacterController : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Field in inspector for reference.")]
    [SerializeField] private Camera m_playerCamera;

    [Tooltip("Character controller top hemisphere point gameObject")]
    [SerializeField] private GameObject m_topHemispherePoint;

    [Tooltip("Character controller bottom hemisphere point gameObject")]
    [SerializeField] private GameObject m_bottomHemispherePoint;

    [Tooltip("Character controller center point gameObject")]
    [SerializeField] private GameObject m_centerPoint;

    [Header("Movement")]
    [Tooltip("Player movement speed.")]
    [SerializeField] private float m_moveSpeed = 10f;

    [Tooltip("Sharpness of movement when player is on ground. Bigger value means sharper movement.")]
    [SerializeField] private float m_movementSharpness = 15f;

    [Tooltip("Max speed in air."), SerializeField]
    private float m_maxSpeedInAir = 10f;

    [Tooltip("Acceleration speed in air.")]
    [SerializeField] private float m_accelerationSpeedInAir = 25f;

    [Tooltip("Layer mask for ground check.")]
    [SerializeField] private LayerMask m_groundCheckLayerMask;

    [Tooltip("Gravity force defines how fast player is falling.")]
    [SerializeField] private float m_gravityForce = 15f;

    [Tooltip("Jump force")]
    [SerializeField] private float m_jumpForce = 10f;

    [Tooltip("How fast player slides from steep slope.")]
    [SerializeField] private float m_slidingFromSlopeSpeed = 1.5f;

    private PlayerInputHandler m_playerInput;
    private CharacterController m_characterController;

    private Vector3 m_playerVelocity = Vector3.zero;
    private Vector3 m_groundNormal = Vector3.up;
    private bool m_isGrounded = false;
    private bool m_isOnSteepSlope = false;



    private void Start()
    {
        m_playerInput = GetComponent<PlayerInputHandler>();
        m_characterController = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        ApplyRotation();
        CheckGround();

        // Get input velocity vector and transform it into world space
        Vector3 movementInput = m_playerInput.GetMoveDirection();
        Vector3 worldspaceInput = transform.TransformVector(movementInput);

        if (m_isGrounded)
        {
            // Get reoriented velocity that is tangent to a given slope
            // Both ways to reorient would work
            //worldspaceInput = Vector3.Cross(m_groundNormal, Vector3.Cross(worldspaceInput, Vector3.up));
            worldspaceInput = Vector3.ProjectOnPlane(worldspaceInput, m_groundNormal).normalized;

            Vector3 targetVelocity = worldspaceInput * m_moveSpeed;

            // Interpolate movement
            m_playerVelocity = Vector3.Lerp(m_playerVelocity, targetVelocity, m_movementSharpness * Time.deltaTime);

            m_playerVelocity.y -= 0.1f;

            if (m_playerInput.GetJumpButtonPressed())
            {
                m_playerVelocity.y = m_jumpForce;
            }
        }

        // It's not perfect but it would be fine for now.
        else
        {
            // Remember vertical velocity
            float verticalVelocity = m_playerVelocity.y;
            Vector3 horizontalVelocity = Vector3.ProjectOnPlane(m_playerVelocity, Vector3.up);
            horizontalVelocity += worldspaceInput * m_accelerationSpeedInAir * Time.deltaTime;

            // Clamp horizontal velocity
            horizontalVelocity = Vector3.ClampMagnitude(horizontalVelocity, m_maxSpeedInAir);

            m_playerVelocity = horizontalVelocity + (Vector3.up * verticalVelocity);

            // Don't ask me how this works
            if (m_isOnSteepSlope)
            {
                Vector3 slopeDirection = Vector3.Cross(Vector3.Cross(m_groundNormal, Vector3.down), m_groundNormal);

                if (Vector3.Dot(m_groundNormal, m_playerVelocity) > 0f)
                {

                    m_playerVelocity += slopeDirection * m_slidingFromSlopeSpeed;
                }
                else
                {
                    m_playerVelocity = slopeDirection * m_slidingFromSlopeSpeed;
                }
                
            }
            else
            {
                m_playerVelocity += Vector3.down * m_gravityForce * Time.deltaTime;
            }
        }

        m_characterController.Move(m_playerVelocity * Time.deltaTime);
    }

    // Check ground sets m_isGrounded value
    private void CheckGround()
    {
        // Reset ground check settings
        m_groundNormal = Vector3.up;
        m_isGrounded = false;
        m_isOnSteepSlope = false;

        // Cast bottom hemisphere down to check collisions
        RaycastHit hit;
        if (Physics.SphereCast(m_bottomHemispherePoint.transform.position, m_characterController.radius, Vector3.down, out hit,
            0.3f, m_groundCheckLayerMask, QueryTriggerInteraction.Ignore))
        {
            m_groundNormal = hit.normal;

            if (Vector3.Dot(m_groundNormal, Vector3.up) > 0f && m_playerVelocity.y <= 0f)
            {
                if (Vector3.Angle(m_groundNormal, Vector3.up) < m_characterController.slopeLimit)
                {
                    m_isGrounded = true;
                }
                else
                {
                    m_isOnSteepSlope = true;
                }
            }
        }
    }

    private void ApplyRotation()
    {
        // Rotate player around Y axis
        float horizontalLook = m_playerInput.GetHorizontalLookAxis();
        transform.rotation = Quaternion.Euler(0f, horizontalLook, 0f);

        // Rotate camera around X axis
        float verticalLook = m_playerInput.GetVerticalLookAxis();
        m_playerCamera.transform.localRotation = Quaternion.Euler(-verticalLook, 0f, 0f);
    }
}
