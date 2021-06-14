using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }
    public void RestoreLightAngle(float angle)
    {
        myLight.spotAngle = angle;
    }
    public void RestoreLightIntensity(float intensity)
    {
        float newIntensity = Mathf.Clamp(myLight.intensity + intensity, 0, 4);
        myLight.intensity += intensity;
    }

    private void DecreaseLightIntensity()
    {
        float newIntensity = myLight.intensity -  Time.deltaTime * lightDecay;

        newIntensity = Mathf.Clamp(newIntensity, 0, Mathf.Infinity);

        myLight.intensity = newIntensity;
    }

    private void DecreaseLightAngle()
    {
        float newSpotAngle = myLight.spotAngle -  Time.deltaTime * angleDecay;

        newSpotAngle = Mathf.Clamp(newSpotAngle, minimumAngle, Mathf.Infinity);

        myLight.spotAngle = newSpotAngle;
    }
}
