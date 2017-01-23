using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class MassObject : MonoBehaviour {
    public float mass = 10f;
    public float velocity = 1;
    public float ice = .5f, rock = .5f, bacteria = .5f;

    public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        MassController.allRigids.Add(this);
    }

    void Update()
    {
        //gameObject.transform.RotateAround(Spawner.centerStar.position, Vector3.up, velocity*Time.deltaTime);
    }

}
