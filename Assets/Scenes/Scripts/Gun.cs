// Author: Brackeys
// Source: https://youtu.be/THnivyG0Mvo
//VR code modified from VR with Andrew: https://youtu.be/OrMVmeVdo-M
using UnityEngine;
using Valve.VR;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 2f; // Lower --> Slower, Higher --> Faster
    public float impactForce = 30f;
    public SteamVR_ActionSet m_ActionSet;
    public SteamVR_Action_Boolean m_BooleanAction;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    private void Awake()
    {
        m_BooleanAction = SteamVR_Actions._default.Shoot;
    }

    private void Start()
    {
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
    }
    // Update is called once per frame
    void Update()
    {
        if (m_BooleanAction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        
    }

    void Shoot()
    {
        muzzleFlash.Play();
        
        RaycastHit hit;
        // if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        if (Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}
