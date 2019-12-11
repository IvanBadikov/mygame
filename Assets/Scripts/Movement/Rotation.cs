using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    [SerializeField]
    private Joystick lookingInput;
    [SerializeField]
    private float rotateSpeed;

    private CharacterController controller;

    private void Start() {
        controller = GetComponent<CharacterController>();
    }
    private void Update() {
        //transform.rotation = 
        //    transform.rotation * Quaternion.Euler(0, rotateSpeed * lookingInput.Horizontal, 0);
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime * lookingInput.Horizontal, 0), Space.Self);
    }
}
