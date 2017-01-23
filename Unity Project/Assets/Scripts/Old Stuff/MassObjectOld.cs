using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class MassObjectOld : MonoBehaviour {
    public float mass = 100f;
    public float range = 25f;
    public float decay = .99999f;
    public float ice = .5f, rock = .5f, bacteria = .5f;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        int type = Random.Range(0, 3);
        if(type == 0)
        {
            ice = 1f;
        }else if(type == 1)
        {
            rock = 1f;
        }else
        {
            bacteria = 1f;
        }
        GetComponent<Renderer>().material.color = new Color(rock*255,bacteria*255,ice*255);
        rb.mass = mass / 1000;
    }

    void OnCollisionEnter(Collision c)
    {
        RunCollide(c);
    }

    void OnCollisionStay(Collision c)
    {

        RunCollide(c);
    }

    void RunCollide(Collision c)
    {
        MassObjectOld otherMass = c.gameObject.GetComponent<MassObjectOld>();
        if (otherMass != null)
        {
            if(Mathf.Abs(otherMass.transform.localScale.magnitude) > Mathf.Abs(transform.localScale.magnitude))
            {

            }
            if (Mathf.Abs(otherMass.rb.velocity.magnitude) > Mathf.Abs(rb.velocity.magnitude))
            {
                mass += otherMass.mass;
                range += otherMass.range/4;
                Vector3 newScale;
                Vector3 addScale;
                if (otherMass.transform.localScale.magnitude < transform.localScale.magnitude)
                {
                    newScale = transform.localScale;
                    addScale = otherMass.transform.localScale * .3f;
                }
                else
                {
                    newScale = otherMass.transform.localScale;
                    addScale = transform.localScale * .3f;
                    transform.position = otherMass.transform.position;
                }
                transform.localScale = newScale+addScale;
                rb.mass = mass / 1000;
                
                Vector3 ourColor = new Vector3(rock, bacteria, ice).normalized;
                Vector3 theirColor = new Vector3(otherMass.rock, otherMass.bacteria, otherMass.ice).normalized;
                GetComponent<Renderer>().material.color = Color.Lerp(new Color(ourColor.x, ourColor.y, ourColor.z), new Color(theirColor.x,theirColor.y,theirColor.z), .25f);
                MassControllerOld.allRigids.Remove(otherMass);
                Destroy(otherMass.gameObject);
                if (mass > MassControllerOld.massToMerge)
                {
                    //rb.constraints = RigidbodyConstraints.FreezePosition;
                    CaptainSoundManager sm = FindObjectOfType<CaptainSoundManager>();
                    sm.PlayRandomSound(sm.planetFormed);
                }

            }
        }

    }
}
