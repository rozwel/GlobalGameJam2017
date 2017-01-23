using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class MassCollider : MassObject
{
    public static float mergeSize = 1000;

    void Start()
    {
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
        MassObject otherMass = c.gameObject.GetComponent<MassObject>();
        if (otherMass != null)
        {
            if (otherMass.tag == "Star")
            {
                DestroyMass(this);
                return;
            }

            if (Mathf.Abs(otherMass.rb.velocity.magnitude) > Mathf.Abs(rb.velocity.magnitude))
            {
                float oldMass = mass;
                mass += otherMass.mass;
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
                transform.localScale = newScale + addScale;
                rb.mass = mass / 1000;

                Vector3 ourColor = new Vector3(rock, bacteria, ice).normalized;
                Vector3 theirColor = new Vector3(otherMass.rock, otherMass.bacteria, otherMass.ice).normalized;
                GetComponent<Renderer>().material.color = Color.Lerp(new Color(ourColor.x, ourColor.y, ourColor.z), new Color(theirColor.x, theirColor.y, theirColor.z), .25f);
                DestroyMass(otherMass);

                if (oldMass <= mergeSize && mass >= mergeSize)
                {
                    //planet made
                    CaptainSoundManager.instance.PlayRandomSound(CaptainSoundManager.instance.planetFormed);
                }
                else
                {
                    //rb.constraints = RigidbodyConstraints.FreezePosition;
                    if (CaptainSoundManager.lastPlayed - Time.time < 0)
                    {
                        float randomVal = Random.Range(0f, 1f);
                        if (randomVal <= .3f)
                        {
                            if (Time.timeSinceLevelLoad >= 5)
                            {
                                CaptainSoundManager.instance.PlayRandomSound(CaptainSoundManager.instance.hitAsteroid);
                                CaptainSoundManager.lastPlayed = Time.time+5;
                            }
                        }
                    }
                }

            }
        }

    }

    private static void DestroyMass(MassObject otherMass)
    {
        MassController.allRigids.Remove(otherMass);
        Destroy(otherMass.gameObject);
    }
}
