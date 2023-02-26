using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour {
    [Header("References")] [SerializeField]
    private CharacterController controller;

    [Header("Settings")] [SerializeField] private float movementSpeed = 5f;
    private const float GRAVITY = -9.81f * 1.5f;

    public Transform groundCheck;
    private const float GROUND_DISTANCE = 0.4f;
    private const float JUMP_HEIGHT = 2f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    private float xRot;
    public GameObject head;

    private Camera cam;

    void Start() {
        if (!isLocalPlayer) {
            Destroy(GetComponent<CharacterController>());
            Destroy(GetComponent<Rigidbody>());
            GetComponentInChildren<Camera>().enabled = false;

            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        cam = Camera.main;
    }

    [ClientCallback]
    private void Update() {
        if (!isLocalPlayer) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 2f)) {
                /*if (hitInfo.transform.TryGetComponent(out Sphere)) {
                    
                }*/
            }
        }

        Move();
        ControlCamera();
    }

    void Move() {
        isGrounded = Physics.CheckSphere(groundCheck.position, GROUND_DISTANCE, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * movementSpeed * Time.deltaTime);

        velocity.y += GRAVITY * Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            velocity.y += Mathf.Sqrt(JUMP_HEIGHT * -2f * GRAVITY);
        }

        controller.Move(velocity * Time.deltaTime);
    }

    void ControlCamera() {
        float mouseX = Input.GetAxis("Mouse X") * 200f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 200f * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        head.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}