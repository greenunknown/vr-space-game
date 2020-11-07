using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLook : MonoBehaviour
{
    // public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    // private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    // private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    private Quaternion startRotation;
    private bool freelook = false;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
        Cursor.lockState = CursorLockMode.Confined; // Keeps the mouse in the center of the screen so that it doesn't 
                                                    // go off for shooting. Press `ESC` to allow mouse to get out of
                                                    // this mode when playing.   
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    // void FixedUpdate()
    void Update()
    {
        // if (Input.GetKey(KeyCode.LeftAlt)) {
        if (Input.GetKey(KeyCode.Tab)) {
            if(!freelook) {
                startRotation = transform.parent.rotation;
                Debug.Log("startRotation: " + startRotation);
                freelook = true;
            }
            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;

            mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y; // Using smaller value to make turning the same speed as 
            mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f); // Make max value <= 1

            transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, 0f, Space.Self);
                        
            // if (Input.GetKeyUp(KeyCode.LeftAlt)) {
            //     // transform.Rotate(prevRotation.x, prevRotation.y, prevRotation.z, Space.Self);
            //     transform.rotation = startRotation;
            //     freelook = false;
            //     Debug.Log("released left alt startRotation: " + startRotation);
            // }
        }
        if (Input.GetKeyUp(KeyCode.Tab)) {
            // transform.Rotate(prevRotation.x, prevRotation.y, prevRotation.z, Space.Self);
            transform.rotation = startRotation;
            freelook = false;
            Debug.Log("released left alt startRotation: " + startRotation);
        }
    }
}
