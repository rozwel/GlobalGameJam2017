using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThruster : MonoBehaviour {

    public float ThrustPower=1;
    public float MaxSpeed = 10;
    public float TurnRate = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, ThrustPower * Input.GetAxis("Vertical") * Time.deltaTime, 0, ForceMode.Acceleration);
        gameObject.transform.Rotate(TurnRate * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0, Space.Self);

    }
}
