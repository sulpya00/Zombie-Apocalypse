//make sure to add a CharacterController to the thing that you want to move
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public CharacterController characterController;

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float speed = 9.0f;


    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        if (characterController.isGrounded)
        {

            characterController.Move(move * speed * Time.deltaTime);


            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }


        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
