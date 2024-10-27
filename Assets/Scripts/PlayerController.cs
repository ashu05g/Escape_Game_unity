using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam; // Reference to the Camera Transform

    public float walkSpeed = 3.0f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public float mouseSensitivity = 100f; // Mouse sensitivity multiplier
    private float xRotation = 0f; // To keep track of camera's x-axis rotation

    private Animator animator; // Reference to Animator component
    public float gravity = -9.81f; // The gravity value
    private Vector3 velocity; // The velocity vector

    public bool isSyringeFound = false, isKeyFound=false;
    public GameObject key, syringe,MainDoor;
    public GameOver gameOver,welcomeCanvas,KeyFindCanvas,goToMainDoorCanvas;

    public AudioSource audioSource;
    public AudioClip audioClip; 
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(syringe.transform.position, transform.position) < 0.8)
        {
            syringe.SetActive(false);
            key.SetActive(true);
            welcomeCanvas.Deactivate();
            KeyFindCanvas.Setup();
            isSyringeFound = true;
        }

        if (isSyringeFound && Vector3.Distance(key.transform.position, transform.position) < 0.8)
        {
            key.SetActive(false);
            KeyFindCanvas.Deactivate();
            isKeyFound = true;
            goToMainDoorCanvas.Setup();
        }

        if (isKeyFound && Vector3.Distance(MainDoor.transform.position, transform.position) < 0.8)
        {
            goToMainDoorCanvas.Deactivate();
            Cursor.lockState = CursorLockMode.Confined; // Lock the cursor to the center of the screen
            Cursor.visible = true; // Show the cursor
            gameOver.Setup();
        }

        // Mouse input for camera look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            audioSource.enabled = true;

            Vector3 moveDirection = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * direction * walkSpeed;
            controller.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            audioSource.enabled = false;
        }

        // Apply gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Apply a small downward force to ensure the character stays grounded
        }

        velocity.y += gravity * Time.deltaTime; // Apply gravity over time
        controller.Move(velocity * Time.deltaTime); // Move the controller down

        if (controller.isGrounded)
        {
            velocity.y = 0f;
        }

        // Update the animator speed
        animator.SetFloat("Speed", walkSpeed * direction.magnitude);
    }
}
