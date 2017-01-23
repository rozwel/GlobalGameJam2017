using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MassControllerOld : MonoBehaviour {


    public static List<MassObjectOld> allRigids = new List<MassObjectOld>();
    public static float massToMerge = 10000;
    bool isStarted = false;
    bool hasRun = false;

    public Text upperLimitText;

	// Use this for initialization
	void Start () {
        Invoke("LateStart", .00000000001f);
	}

    IEnumerator coroutine;

    void LateStart()
    {
        foreach (MassObjectOld mo in GameObject.FindObjectsOfType<MassObjectOld>())
        {
            allRigids.Add(mo);
        }
        isStarted = true;
        coroutine = MyFixedUpdate();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    private IEnumerator MyFixedUpdate ()
    {
        int upperLimit = 300;
        int counter = 0;
        float framerateMultiplier = 1;
        while (isStarted && allRigids.Count >1)// && !hasRun)
        {
            for (int i = 0; i < allRigids.Count; i++)
            {
                MassObjectOld thisOne = allRigids[i];
                for (int j = i+1; j < allRigids.Count; j++)
                {
                    
                    MassObjectOld other = allRigids[j];
                    
                    if (thisOne != null && other != null)
                    {
                        float distance = Vector3.Distance(thisOne.transform.position, other.transform.position);
                        if (distance <= thisOne.range)
                        {
                            counter++;
                            if (other != thisOne && other != null)
                            {
                                Vector3 direction = (other.transform.position - thisOne.transform.position).normalized;
                                float rangePercent = (1 - Mathf.Clamp((distance / thisOne.range), 0, 1));
                                //print("force = " + (direction * other.mass * rangePercent) + ", Dir: " + direction + ", mass: " + other.mass + ", range: " + rangePercent);
                                thisOne.rb.AddForce((direction * other.mass * rangePercent) * (framerateMultiplier * Time.deltaTime));
                                thisOne.rb.velocity = new Vector3(thisOne.rb.velocity.x, 0, thisOne.rb.velocity.z);
                            }
                        }
                        if (distance <= other.range)
                        {
                            counter++;
                            if (other != thisOne && other != null)
                            {

                                Vector3 direction = (thisOne.transform.position - other.transform.position).normalized;
                                float rangePercent = (1 - Mathf.Clamp((distance / other.range), 0, 1));
                                other.rb.AddForce((direction * thisOne.mass * rangePercent) * (framerateMultiplier * Time.deltaTime));
                                other.rb.velocity = new Vector3(other.rb.velocity.x, 0, other.rb.velocity.z);
                            }
                        }

                    }
                }
                if (counter >= upperLimit)
                {
                    if (1.0f / Time.deltaTime > 60)
                    {
                        upperLimit += 10;
                        //print("Increased upper limit: " + upperLimit);
                    }
                    if (1.0f / Time.deltaTime < 40)
                    {
                        upperLimit -= 10;
                        //print("Decreased upper limit: " + upperLimit + ", " + (1.0f / Time.deltaTime));
                    }
                    upperLimit = Mathf.Clamp(upperLimit, 100, allRigids.Count);
                    framerateMultiplier = allRigids.Count / upperLimit;
                    if (upperLimitText != null)
                    {
                        upperLimitText.text = ((int)upperLimit).ToString();
                    }
                    counter = 0;
                    thisOne.transform.position = new Vector3(thisOne.transform.position.x, 0, thisOne.transform.position.z);
                    yield return new WaitForEndOfFrame();
                }
                //print("RanLoop");
            }
            //print("Ran " + counter + " times");
            hasRun = true;
        }
    }


}
