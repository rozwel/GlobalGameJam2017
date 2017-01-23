using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarWind : MonoBehaviour
{
    //public float thrust = 5000;
    //public Quaternion direction;
    //public float speed;
    //public bool surfing = false;

    public float speed = 5.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //col.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
            //Debug.Log("Called Add Velocity");
            //col.gameObject.GetComponent<Rigidbody>().velocity += Vector3.forward * thrust;
            //direction = transform.forward;
            //surfing = true;

            //col.GetComponent<ShipThruster>().newDirection = transform.forward;
            //col.GetComponent<ShipThruster>().surfing = true;
            //col.GetComponent<Rigidbody>().velocity = transform.forward * speed;

            col.GetComponent<ShipThruster>().StartSurf(transform.forward * 10.0f);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 4.0f);
    }
}
