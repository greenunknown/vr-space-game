using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ship;
    void Start()
    {
        Debug.Log(transform.position);
        ship.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - .35f, this.transform.position.z + .94f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
