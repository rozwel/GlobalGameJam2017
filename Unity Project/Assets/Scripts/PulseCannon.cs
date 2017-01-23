using UnityEngine;

public class PulseCannon : MonoBehaviour
{
    public float Range = 1;
    public float Force = 10;

    void OnTriggerEnter(Collider other)
    {
        /*
            var direction = (other.transform.position - transform.position).normalized;
            direction = new Vector3(direction.x, 0, direction.z);
            var distance = Vector3.Distance(other.transform.position, transform.position);
            other.GetComponent<Rigidbody>().AddForce(direction * Force);
            */
        if (other.GetComponent<MassObject>() != null)
        {
            other.transform.rotation = transform.rotation;
            other.transform.Rotate(new Vector3(0, 90, 0));
            other.GetComponent<Rigidbody>().velocity += (other.transform.forward * Force);
        }
    }
}