using UnityEngine;

public class PulseCannon : MonoBehaviour {
    public float Range = 1;
    public float Force = 10;
    private bool firing = false;
   
  	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        firing = Input.GetButton("Fire1");
	}

    void OnTriggerStay(Collider other)
    {
        if (firing)
        { 
            var direction = (other.transform.position - transform.position).normalized;
            direction = new Vector3(direction.x, 0, direction.z);
            var distance = Vector3.Distance(other.transform.position, transform.position);
            other.GetComponent<Rigidbody>().AddForce(direction * Force);
        }
    }
}
