using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{   
    [SerializeField] Camera FPCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;//i dont realy love this approach
    [SerializeField] float zoom = 2f;
    [SerializeField] float mouseSensitivity = 4f;

    bool isZoomed = false;

    public bool IsZoomed { get { return isZoomed; } }
   
    // Update is called once per frame
    void Update()
    {
        ProcessZoom();
    }
    
    void ProcessZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = true;
            FPCamera.fieldOfView /= zoom;
            fpsController.mouseLook.XSensitivity /= mouseSensitivity;
            fpsController.mouseLook.YSensitivity /= mouseSensitivity;

            //TODO: Fine a way to replace the code above with this method
            //SetZoomValues(bool isZoomed, Operator operator);
        }

        if (Input.GetMouseButtonUp(1))
        {
            isZoomed = false;
            FPCamera.fieldOfView *= zoom;
            fpsController.mouseLook.XSensitivity *= mouseSensitivity;
            fpsController.mouseLook.YSensitivity *= mouseSensitivity;

            //TODO: Fine a way to replace the code above with this method
            //SetZoomValues(bool isZoomed, Operator operator);
        }
    }

    //TODO: Fine a way to do this
    /*
      void SetZoomValues(bool isZoomed, Operator operator)
      {
            isZoomed = isZoomed;
            FPCamera.fieldOfView operator zoom;
            fpsController.mouseLook.XSensitivity operator mouseSensitivity;
            fpsController.mouseLook.YSensitivity operator mouseSensitivity;
      }
    */

    
}
