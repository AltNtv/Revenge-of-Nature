using UnityEngine;


[RequireComponent(typeof(PlayerInputHandler), typeof(CharacterController))]
internal sealed class PlayerCharacterController : MonoBehaviour
{
    [Tooltip("Character controller top hemisphere point gameObject")]
    [SerializeField] private GameObject m_topHemispherePoint;

    [Tooltip("Character controller bottom hemisphere point gameObject")]
    [SerializeField] private GameObject m_bottomHemispherePoint;

    [Tooltip("Character controller center point gameObject")]
    [SerializeField] private GameObject m_centerPoint;

    [Tooltip("Field in inspector for reference.")]
    [SerializeField] private Camera m_playerCamera;

    [Tooltip("Player movement speed.")]
    [SerializeField] private float m_moveSpeed;

    [Tooltip("Layer mask for ground check.")]
    [SerializeField] private LayerMask m_groundCheckLayerMask;

    private PlayerInputHandler m_playerInput;
    private CharacterController m_characterController;

    private bool m_isGrounded;


    private void Start()
    {
        m_playerInput = GetComponent<PlayerInputHandler>();
        m_characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Rotate player around Y axis
        float horizontalLook = m_playerInput.GetHorizontalLookAxis();
        transform.rotation = Quaternion.Euler(0f, horizontalLook, 0f);

        // Rotate camera around X axis
        float verticalLook = m_playerInput.GetVerticalLookAxis();
        m_playerCamera.transform.localRotation = Quaternion.Euler(-verticalLook, 0f, 0f);

        // Get input velocity vector and transform it into world space
        Vector3 velocity = m_playerInput.GetMoveDirection() * (m_moveSpeed * Time.deltaTime);
        Vector3 velocityInWorldSpace = transform.TransformVector(velocity);

        if (m_isGrounded)
        {
            velocityInWorldSpace.y = -0.5f;
        }
        else
        {
            velocityInWorldSpace.y += -9.81f * Time.deltaTime;
        }

        m_characterController.Move(velocityInWorldSpace);
    }

    private bool CheckGround()
    {
        // Cast bottom hemisphere down to check collisions
        RaycastHit hit;
        if (Physics.SphereCast(m_bottomHemispherePoint.transform.position, m_characterController.radius, Vector3.down, out hit,
            0.2f, m_groundCheckLayerMask, QueryTriggerInteraction.Ignore))
        {
            // Don't consider bad angles and sharp slopes as ground
            if (Vector3.Dot(hit.normal, Vector3.up) > 0f && Vector3.Angle(hit.normal, Vector3.up) < m_characterController.slopeLimit)
            {
                return true;
            }
        }
        return false;
    }

    // I used it to look how hemisphere points are positioned
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(m_topHemispherePoint.transform.position, m_characterController.radius);
    //    Gizmos.DrawWireSphere(m_bottomHemispherePoint.transform.position, m_characterController.radius);
    //}
}
