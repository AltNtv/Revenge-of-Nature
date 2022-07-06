using UnityEngine;


[RequireComponent(typeof(PlayerInputHandler), typeof(CharacterController))]
public class PlayerCharacterController : MonoBehaviour
{
    private PlayerInputHandler m_playerInput;
    private CharacterController m_characterController;


    private float m_playerSpeed = 5f;


    private void Start()
    {
        m_playerInput = GetComponent<PlayerInputHandler>();
        m_characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 direction = m_playerInput.GetMoveDirection();
        m_characterController.Move(direction * (Time.deltaTime * m_playerSpeed));
    }
}
