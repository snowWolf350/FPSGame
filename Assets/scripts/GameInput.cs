using UnityEngine;

public class GameInput : MonoBehaviour
{

    public PlayerInput PlayerInput;
    PlayerMovement PlayerMovement;
    PlayerLook PlayerLook;

    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerLook = GetComponent<PlayerLook>();
        PlayerInput = new PlayerInput();
        PlayerInput.Player.Jump.performed += Jump_performed;
        PlayerInput.Player.Sprint.performed += Sprint_performed;
    }

    private void Sprint_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        PlayerMovement.Sprint();
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        PlayerMovement.Jump();
    }

    private void FixedUpdate()
    {
        PlayerMovement.ProcessMove(PlayerInput.Player.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        PlayerLook.ProcessLook(PlayerInput.Player.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        PlayerInput.Player.Move.Enable();
        PlayerInput.Player.Jump.Enable();
        PlayerInput.Player.Look.Enable();
        PlayerInput.Player.Sprint.Enable();
        PlayerInput.Player.Interact.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Player.Jump.Enable();
        PlayerInput.Player.Move.Disable();
        PlayerInput.Player.Look.Disable();
        PlayerInput.Player.Sprint.Disable();
        PlayerInput.Player.Interact.Disable();
    }
}
