using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera; //now this script can access aanything from camera as its connected in inspector
    [SerializeField] RigidbodyFirstPersonController fpsController; //to not get the component each time we assign a variable to it
    //changing it to seriaalize field as we put the weapon zoom on the weapon now instead of the player
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;
    
    bool zoomedInToggle = false;
    private void OnDisable() //zoomed in toggle in the debug mode of inspector
    {
        ZoomOut();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if (zoomedInToggle == false) // logic for zoom in
            {
                ZoomIn();
            }
            else //logic for zoom out
            {
                ZoomOut();
            }
        }
    }


    private void ZoomIn()
    {
        zoomedInToggle = true; //if player is not zoomed in zoom in
        fpsCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }

     private void ZoomOut()
    {
        zoomedInToggle = false; //if player is zoomed in zoom out
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }
}
