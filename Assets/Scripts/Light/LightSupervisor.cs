using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightSupervisor : MonoBehaviour {
    private const int MIN_INTENCITY = 0;

    private Light subordinateLight;

    private float startIntensity;
    private float startRange;

    private Coroutine masterCoroutine;

    private void Start() {
        subordinateLight = GetComponent<Light>();

        startIntensity = subordinateLight.intensity;
        startRange = subordinateLight.range;
    }

    public void CallFlash() {
        masterCoroutine = CallCoroutine(startAfter(increaseIntencity(startIntensity, Time.deltaTime), decreasingIntencity(MIN_INTENCITY, Time.deltaTime)));
    }

    private Coroutine CallCoroutine(IEnumerator coroutine) {
        if (masterCoroutine != null) {
            return null;
        }

        return StartCoroutine(coroutine);
    }
    private IEnumerator startAfter(IEnumerator startsFirst, IEnumerator startsAfter) {
        yield return CallCoroutine(startsFirst);
        CallCoroutine(startsAfter);
    }
    private IEnumerator increaseIntencity(float untill, float step) {
        #if UNITY_EDITOR
        if (subordinateLight.intensity <= untill) {
            Debug.LogWarning("Check your light.");
        }
        #endif

        step = Mathf.Abs(step);
        
        while(subordinateLight.intensity < untill) {
            subordinateLight.intensity += step;

            yield return null;
        }

        yield return null;
    }
    private IEnumerator decreasingIntencity(float untill, float step) {
        #if UNITY_EDITOR
        if (subordinateLight.intensity <= untill) {
            Debug.LogWarning("Check your light.");
        }
        #endif
        
        step = Mathf.Abs(step);

        while(subordinateLight.intensity > untill) {
            subordinateLight.intensity -= step;

            yield return null;
        }

        yield return null;
    }
}
