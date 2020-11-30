using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thruster : MonoBehaviour
{
    public Transform positionMarker;
    public ShipController ship;
    public Transform cam;
    public Vector3 allignment;
    [SerializeField]
    private float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.position = cam.position + allignment;
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.localPosition.x;
        if(x > -.1f && x <= 0f)
        {
            speed = 0f;
        }
        else if(x <= -.1f)
        {
            speed = x + .1f;
        }
        else
        {
            speed = x;
        }
        speed *= 10;
        Debug.Log("speed" + speed);
        ship.thrust(speed);
        //call thrust
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand")){
            Vector3 oldPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
            positionMarker.position = other.transform.position;
            positionMarker.localPosition = new Vector3(positionMarker.localPosition.x, oldPos.y, oldPos.z);
            if (positionMarker.localPosition.x >= -.2 && positionMarker.localPosition.x <= .2)
            {
                transform.position = positionMarker.position;
            }
            else
            {
                positionMarker.position = transform.position;
            }
        }
    }
}
