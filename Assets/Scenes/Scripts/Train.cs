using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float trainSpeed = 5f;
    public float initialPosition;
    public float currentDistance = 0f;
    public float maxDistance = 100f;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position.z;
        // Debug.Log("Inital position: " + initialPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDistance < maxDistance)
        {
            currentDistance = transform.position.z - initialPosition; 
            // Debug.Log("Current position: " + transform.position.z);
            transform.position += transform.forward * trainSpeed * Time.deltaTime;
        }
        
    }
}
