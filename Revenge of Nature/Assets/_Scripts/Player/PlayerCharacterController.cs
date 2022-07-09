using UnityEngine;


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

    [Header("General")]
    [Tooltip("Player movement speed.")]
    [SerializeField] private float m_moveSpeed = 10f;

    [Tooltip("Acceleration speed in air.")]
    [SerializeField] private float m_accelerationSpeedInAir = 25f;

    [Tooltip("Max speed in air."), SerializeField]
    private float m_maxSpeedInAir = 10f;

    [Tooltip("Layer mask for ground check.")]
    [SerializeField] private LayerMask m_groundCheckLayerMask;

    [Tooltip("Gravity force defines how fast player is falling.")]
    [SerializeField] private float m_gravityForce;

    [Tooltip("Sharpness of movement when player is on ground. Bigger value means sharper movement.")]
    [SerializeField] private float m_movementSharpness = 15f;

    private PlayerInputHandler m_playerInput;
    private CharacterController m_characterController;

    private Vector3 m_playerVelocity = Vector3.zero;
    private Vector3 m_groundNormal;
    private bool m_isGrounded;



    private void Start()
    {
        m_playerInput = GetComponent<PlayerInputHandler>();
        m_characterController = GetComponent<CharacterController>();
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
            worldspaceInput = Vector3.Cross(m_groundNormal, Vector3.Cross(worldspaceInput, Vector3.up));

            Vector3 targetVelocity = worldspaceInput * m_moveSpeed;

            // Interpolate movement
            m_playerVelocity = Vector3.Lerp(m_playerVelocity, targetVelocity, m_movementSharpness * Time.deltaTime);

            m_playerVelocity.y -= 0.1f;
        }

        else
        {
            m_playerVelocity += worldspaceInput * (m_accelerationSpeedInAir * Time.deltaTime);

            // Remember vertical velocity
            float verticalVelocity = m_playerVelocity.y;
            Vector3 horizontalVelocity = Vector3.ProjectOnPlane(m_playerVelocity, Vector3.up);


            // Clamp horizontal velocity
            horizontalVelocity = Vector3.ClampMagnitude(horizontalVelocity, m_maxSpeedInAir);

            m_playerVelocity = horizontalVelocity + (Vector3.up * verticalVelocity);
            m_playerVelocity += Vector3.down * m_gravityForce * Time.deltaTime;
        }

        m_characterController.Move(m_playerVelocity * Time.deltaTime);
    }

    // Check ground sets m_isGrounded value
    private void CheckGround()
    {
        // Cast bottom hemisphere down to check collisions
        RaycastHit hit;
        if (Physics.SphereCast(m_bottomHemispherePoint.transform.position, m_characterController.radius, Vector3.down, out hit,
            0.2f, m_groundCheckLayerMask, QueryTriggerInteraction.Ignore))
        {
            m_groundNormal = hit.normal;

            // Consider hit as valid ground if only ground normal goes up
            // and ground slope is not more than character controller slope limit
            if (Vector3.Dot(hit.normal, Vector3.up) > 0f && Vector3.Angle(hit.normal, Vector3.up) < m_characterController.slopeLimit)
            {
                m_isGrounded = true;
            }
            else
            {
                m_isGrounded = false;
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
