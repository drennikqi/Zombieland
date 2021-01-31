using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{

    [SerializeField] float lightDecay = 1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;

    Light myLight;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecresaLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle) {
        myLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float intensityAmount) {
        myLight.intensity += intensityAmount;
    }

    private void DecreaseLightAngle() {
        if(myLight.spotAngle <= minAngle) {
            return;
        } else {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecresaLightIntensity() {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
