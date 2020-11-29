using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code based on Mr.Pineapple Studio's Joystick: https://youtu.be/pPDIFBxX7Gs
public class VRJoystick : MonoBehaviour
{
    public Transform top;
    public Transform euTarget;
    public Transform cam;
    public ShipController ship;
    public float smooth = 5f;
    public Vector3 alignment;


    [SerializeField]
    private float forwardTilt = 0;
    [SerializeField]
    private float sideTilt = 0;

    private Vector3 resetEA;
    private Quaternion relativeRotation;
    // Start is called before the first frame update
    void Start()
    {
        resetEA = transform.localEulerAngles;
        transform.position = cam.position + alignment;
        //get relative rotation source: https://answers.unity.com/questions/1081084/matching-rotation-of-one-object-to-another-c.html
        relativeRotation = Quaternion.Inverse(top.rotation) * euTarget.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        bool move = false;
        euTarget.rotation = relativeRotation * top.rotation;
        forwardTilt = euTarget.localEulerAngles.x;
        sideTilt = euTarget.localEulerAngles.z;
        if(forwardTilt < 355 && forwardTilt > 290)
        {
            move = true;
            forwardTilt = Mathf.Abs(forwardTilt - 360);
            Debug.Log("Backward" + forwardTilt);
        }
        else if (forwardTilt > 5 && forwardTilt < 74)
        {
            move = true;
            forwardTilt = -forwardTilt;
            Debug.Log("Forward" + forwardTilt);
        }
        if(sideTilt > 5 && sideTilt < 74)
        {
            move = true;
            sideTilt = -sideTilt;
            Debug.Log("Left" + sideTilt);
        }
        else if (sideTilt < 355 && sideTilt > 290)
        {
            move = true;
            sideTilt = Mathf.Abs(sideTilt - 360);
            Debug.Log("Right" + sideTilt);
        }
        if (move)
        {
            ship.tilt(Vector2.ClampMagnitude(new Vector2(sideTilt, forwardTilt), 1f));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PlayerHand"))
        {
            transform.localEulerAngles = resetEA;
        }
    }
}
