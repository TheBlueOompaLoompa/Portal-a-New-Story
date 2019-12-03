using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float runSpeed = 4;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public Vector3 VELOCITY;
    public bool isGrounded;
    public bool isRunning;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move;

        if ((x > 0 && z > 0) || (x < 0 && z < 0))
        {
            move = (transform.right * x + transform.forward * z) / 1.5f;
        }
        else
        {
            move = (transform.right * x + transform.forward * z);
        }

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
                controller.Move(move * (speed + runSpeed) * Time.deltaTime);
            }
            else
            {
                isRunning = false;
                controller.Move(move * speed * Time.deltaTime);
            }
        }
        else
        {
            controller.Move(move * (speed - (speed / 100)) * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (velocity.y > -40)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_STANDALONE_WIN
            Application.Quit();
#endif
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        VELOCITY = velocity;
        VELOCITY.x = move.x;
        VELOCITY.z = move.z;
    }
}
