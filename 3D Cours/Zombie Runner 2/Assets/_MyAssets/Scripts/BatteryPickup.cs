using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;

    void OnTriggerEnter(Collider other)
    {
        FlashLightSystem flashLight = other.GetComponentInChildren<FlashLightSystem>();

        if (flashLight)
        {
            flashLight.RestoreLightAngle(restoreAngle);
            flashLight.AddLightIntensity(addIntensity);
            Destroy(gameObject);
        }
    }
}
