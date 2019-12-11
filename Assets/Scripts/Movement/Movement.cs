using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private Joystick movementInput;
    private CharacterController controller;

    private Vector3 movementDirection;
    private Vector3 forwardDirection;
    private Vector3 sideDirection;

    private void Start() {
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        /*movementDirection = new Vector3(
            movementInput.Horizontal,
            0,
            movementInput.Vertical
        );*/

        forwardDirection = transform.TransformDirection(Vector3.forward);
        sideDirection = transform.TransformDirection(Vector3.right);

        movementDirection = (forwardDirection * movementInput.Vertical) + (sideDirection * movementInput.Horizontal);

        controller.Move(movementDirection * speed * Time.deltaTime);
    }
}
