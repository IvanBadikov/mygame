using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInfo : MonoBehaviour {
    public static JoystickInfo get;
    
    [SerializeField]
    private Joystick joystick_movementInput;
    [SerializeField]
    private Joystick joystick_lookingInput;

    public float ForwardWalking {
        get {
            return joystick_movementInput.Vertical;
        }
        private set {}
    }
    public float SideWalking {
        get {
            return joystick_movementInput.Horizontal;
        }
        private set {}
    }

    public float AbsForwardWalking {
        get {
            return Mathf.Abs(ForwardWalking);
        }
        private set {}
    }
    public float AbsSideWalking { 
        get {
            return Mathf.Abs(SideWalking);
        }
        private set {

        }
    }

    public float Looking {
        get {
            return joystick_lookingInput.Horizontal;
        }
    }
    public float AbsLooking {
        get {
            return Mathf.Abs(Looking);
        } 
        private set {
            
        }
    }

    private void Start() {
        get = this;
    }
}
