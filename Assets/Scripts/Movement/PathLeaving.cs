using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLeaving : MonoBehaviour
{
    private const int NO_AFFECT = 0;

    [SerializeField]
    private GameObject stepObject;
    [SerializeField]
    private float stepLength;
    [SerializeField]
    private float stepAltitude;
    [SerializeField]
    private int maxSteps;

    private List<GameObject> steps;

    private float currentStep;

    private void Start() {
        steps = new List<GameObject>();
    }

    private void Update() {
        currentStep += (JoystickInfo.get.AbsForwardWalking + JoystickInfo.get.AbsForwardWalking) * Time.deltaTime;

        if (currentStep > stepLength) {
            MakeStep();

            currentStep = 0;
        }
    }

    private void CheckList() {
        if (steps.Count > maxSteps) {
            Destroy(steps[0]);
            steps.RemoveAt(0);
        }
    }
    private void LeaveStep() {
        GameObject newStep = Instantiate(stepObject);

        newStep.transform.position = transform.position - new Vector3(NO_AFFECT, stepAltitude, NO_AFFECT);

        steps.Add(newStep);
    }

    private void MakeStep() {
        CheckList();

        LeaveStep();
    }
}
