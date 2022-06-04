using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    #region variaveis
    Character character;
    Vector3 moveDirection;
    Vector3 velocity;
    bool isGrounded;
    bool isJumping;
    float groundCheckDistance = 1f;
    float gravity = -9.8f;  
    float moveSpeed;
    float walkSpeed = 2;
    float runSpeed = 4;
    float jumpHeight = 0.8f;
    float rotationValue = 100;
    LayerMask groundMask;
    #endregion
    void Start()
    {
        character = GetComponent<Character>();
        groundMask = character.groundMask;
    }
    #region Metodos
    public void Move()
    {
        Rotate();
         isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        var vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, vertical);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            AnimationControll();
            isJumping = false;
            if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     Jump();
            // }
        }
        character.player.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        if ((isJumping && velocity.y < 0) || (!isJumping && !isGrounded))
        {
            character.anim.SetBool("isGrounded", false);
            character.anim.SetBool("isFalling", true);
        }
        character.player.Move(velocity * Time.deltaTime);

    }
    private void AnimationControll()
    {
        character.anim.SetBool("isGrounded", true);
        character.anim.SetBool("isFalling", false);
        character.anim.SetBool("isJumping", false);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        character.anim.SetBool("isJumping", true);
        isJumping = true;
    }
    private void Run()
    {
        moveSpeed = runSpeed;
        character.anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);

    }
    private void Walk()
    {
        moveSpeed = walkSpeed;
        character.anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
    private void Idle()
    {
        character.anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }
    private void Rotate()
    {
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * rotationValue;
        this.transform.Rotate(Vector3.up, horizontal);
    }
    #endregion

}