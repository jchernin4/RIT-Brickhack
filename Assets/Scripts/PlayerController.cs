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
            GetComponentInChildren<Camera>().enabled = false;
            return;
        }
        
        transform.position = new Vector3(0, 5f, 0f);
    }

    [ClientCallback]
    private void Update() {
        if (!isLocalPlayer) { return; }

        var movement = new Vector3();

        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        controller.Move(movement * movementSpeed * Time.deltaTime);

       /* if (controller.velocity.magnitude > 0.2f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }*/
    }
}