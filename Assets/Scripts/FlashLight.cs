using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightDecay = 5.0f; // Rate at which light intensity decreases (adjust as needed)
    [SerializeField] float angleDecay = 50.0f; // Rate at which light angle decreases (adjust as needed)
    [SerializeField] float minimumAngle = 40f; // Minimum angle the light can reach
    [SerializeField] float fadeUpSpeed = 10.0f; // Speed at which light fades back up
    [SerializeField] float restartDelay = 1.0f; // Delay before restarting the flashlight

    Light myLight;
    float originalIntensity;
    float originalAngle;
    bool isFadingUp = false;

    private void Start()
    {
        myLight = GetComponent<Light>();
        originalIntensity = myLight.intensity;
        originalAngle = myLight.spotAngle;
    }

    private void Update()
    {
        if (!isFadingUp)
        {
            DecreaseLightAngle();
            DecreaseLightIntensity();
        }

        if (myLight.intensity <= 0 && !isFadingUp)
        {
            // Wait for the specified delay before restarting the flashlight
            StartCoroutine(RestartFlashlight());
        }
        else if (isFadingUp)
        {
            FadeUpLight();
        }
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void FadeUpLight()
    {
        myLight.intensity += fadeUpSpeed * Time.deltaTime;
        myLight.spotAngle += fadeUpSpeed * Time.deltaTime;

        // Clamp values to their original values to avoid overshooting
        myLight.intensity = Mathf.Clamp(myLight.intensity, 0f, originalIntensity);
        myLight.spotAngle = Mathf.Clamp(myLight.spotAngle, minimumAngle, originalAngle);

        // Check if we've reached or exceeded the original values
        if (myLight.intensity >= originalIntensity && myLight.spotAngle >= originalAngle)
        {
            isFadingUp = false;
        }
    }

    IEnumerator RestartFlashlight()
    {
        yield return new WaitForSeconds(restartDelay);

        // Reset the flashlight parameters
        myLight.intensity = 0f; // Start from zero intensity
        myLight.spotAngle = minimumAngle; // Start from minimum angle
        isFadingUp = true;
    }
}