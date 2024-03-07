using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 20f;
    public float defaultSpeed = 4f;
    public float sprintSpeed = 8f;
    public float maxDebufSpeed = 3.5f;
    public float debufSpeed = 0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    public bool isGrounded;

    public Animator animator;

    public Vector3 velocity;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0 && gravity < 0)
        {
            velocity.y = -2f;
        }
        else if (isGrounded && velocity.y > 0 && gravity > 0)
        {
            velocity.y = 2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        var revert = 1f;
        if (gravity > 0)
            revert = -1f;

        Vector3 move = transform.right * x * revert + transform.forward * z;
        Vector3 motion = move * speed * Time.deltaTime;

        controller.Move(motion);

        if (motion.sqrMagnitude > 0.00005f)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetButton("Sprint") && z > 0)
        {
            speed = sprintSpeed - debufSpeed * 2;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            speed = defaultSpeed - debufSpeed;
            animator.SetBool("IsRunning", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(Mathf.Abs(jumpHeight * gravity)) * revert;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiply">From 0.0 to 1.0</param>
    public void SetDebufSpeed(float multiply)
    {
        debufSpeed = maxDebufSpeed * multiply;
    }

    public void ReverseGravity()
    {
        gravity = -gravity;
        animator.SetBool("IsReverseGravity", gravity > 0);
        Camera.main.GetComponent<MouseInput>().isReverted = gravity > 0;
    }
}
