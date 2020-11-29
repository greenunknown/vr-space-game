using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLook : MonoBehaviour
{
    public Transform target;
    public float range = 25f;

    private float turret_down_look = -1;
    // Start is called before the first frame update
    void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    {
        // transform.LookAt(target); 
        if ((target.position.x - transform.position.x) < range && (target.position.z - transform.position.z) < range) 
        {
            if ((target.position.y - transform.position.y) > turret_down_look) 
            {
                Vector3 relativePos = target.position - transform.position;
                Debug.Log("relativePos: " + relativePos + " tary - tray: " + (target.position.y - transform.position.y));
                // the second argument, upwards, defaults to Vector3.up
                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                transform.rotation = rotation; 
            }
        } 
        // Vector3 relativePos = target.position - transform.position;
        // Debug.Log("relativePos: " + relativePos + " tary - tray: " + (target.position.y - transform.position.y));
        // // the second argument, upwards, defaults to Vector3.up
        // Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        // transform.rotation = rotation; 
    }
}
