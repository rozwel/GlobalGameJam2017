using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThruster : MonoBehaviour {

    public float ThrustPower=1;
    public float MaxSpeed = 10;
    public float TurnRate = 10;
    public GameObject camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(-ThrustPower * Input.GetAxis("Vertical") * Time.deltaTime, 0, 0, ForceMode.Acceleration);
        gameObject.transform.Rotate(0, TurnRate * Input.GetAxis("Horizontal") * Time.deltaTime, 0, Space.Self);
        camera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 35, gameObject.transform.position.z);
    }
}
