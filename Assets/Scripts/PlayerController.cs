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
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    void Start() {
        if (!isLocalPlayer) {
            Destroy(GetComponent<CharacterController>());
            Destroy(GetComponent<Rigidbody>());
            GetComponentInChildren<Camera>().enabled = false;
        }
    }

    [ClientCallback]
    private void Update() {
        if (!isLocalPlayer) {
            return;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, GROUND_DISTANCE, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * movementSpeed * Time.deltaTime);

        velocity.y += GRAVITY * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}