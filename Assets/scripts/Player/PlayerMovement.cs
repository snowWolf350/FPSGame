using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController CharacterController;
    Vector3 playerVelocity;
    float speed = 5f;
    bool isGrounded;
    float gravity = -9.8f;
    float jumpHeight = 1f;
    bool sprinting;

    private void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        playerVelocity = new Vector3(0, -1, 0);
    }

    public void ProcessMove(Vector2 Input)
    {
        isGrounded = CharacterController.isGrounded;
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.x;
        moveDir.z = Input.y;
        CharacterController.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        playerVelocity.y += gravity * Time.deltaTime;
        CharacterController.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
            speed = 8;
        else
            speed = 5;
    }
}
