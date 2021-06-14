using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float intensity = 3f;
    [SerializeField] float angle = 70f;
    private void OnTriggerEnter(Collider other)
    {
        FlashLightSystem lightSystem = other.GetComponentInChildren<FlashLightSystem>();
        if (other.gameObject.tag == "Player"&&lightSystem!=null)
        {
            lightSystem.RestoreLightAngle(angle);
            lightSystem.RestoreLightIntensity(intensity);
            Destroy(gameObject);
        }
    }
}
