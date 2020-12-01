using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipAlign : MonoBehaviour
{
    public Transform cam;
    public Vector3 alignment;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = cam.position + alignment;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
