using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarWind : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float thrust;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "player_obj")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
        }
    }
}
