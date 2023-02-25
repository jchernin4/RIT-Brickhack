using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour {
    [Header("References")]
    [SerializeField] private CharacterController controller;

    [Header("Settings")]
    [SerializeField] private float movementSpeed = 5f;

    void Start() {
        if (!isLocalPlayer) {
            Destroy(GetComponent<CharacterController>());
            Destroy(GetComponent<Rigidbody>());
            GetComponentInChildren<Camera>().enabled = false;
        }
    }

    [ClientCallback]
    private void Update() {
        if (!isLocalPlayer) { return; }

        Vector3 movement = new Vector3();

        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        controller.Move(movement * (movementSpeed * Time.deltaTime));

       /* if (controller.velocity.magnitude > 0.2f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }*/
    }
}