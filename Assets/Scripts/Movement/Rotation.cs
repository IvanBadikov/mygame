using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    private const int NO_AFFECT = 0;

    [SerializeField]
    private float rotateSpeed;

    private void Update() {
        transform.Rotate(new Vector3(NO_AFFECT, rotateSpeed * Time.deltaTime * JoystickInfo.get.Looking, NO_AFFECT), Space.Self);
    }
}
