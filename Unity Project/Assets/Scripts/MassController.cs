using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MassController : MonoBehaviour {


    public static List<MassObject> allRigids = new List<MassObject>();
    public float gravityConst = 1;
    public float gravityCutoff = 10;
    bool isStarted = false;

    public Text upperLimitText;

    // Use this for initialization
    void Start() {
        Invoke("LateStart", .00000000001f);
    }

    IEnumerator coroutine;

    void LateStart()
    {
        //foreach (MassObject mo in GameObject.FindObjectsOfType<MassObject>())
        //{
        //    allRigids.Add(mo);
        //}
        isStarted = true;
        coroutine = MyFixedUpdate();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    private IEnumerator MyFixedUpdate()
    {
        int upperLimit = 300;
        int counter = 0;
        float framerateMultiplier = 1;
        while (isStarted)// && !hasRun)
        {
            if (allRigids.Count <= 1)
            {
                yield return new WaitForEndOfFrame();
            }
            for (int i = 0; i < allRigids.Count; i++)
            {
                MassObject thisOne = allRigids[i];
                for (int j = i + 1; j < allRigids.Count; j++)
                {

                    counter++;
                    MassObject other = allRigids[j];

                    if (thisOne != null && other != null)
                    {
                        var distance = getDistance(thisOne, other);
                        if (distance > 50) continue;

                        var attraction = getAttraction(thisOne, other)*gravityConst;
                        if (other != thisOne && other != null)
                        {

                            Vector3 direction = (other.transform.position - thisOne.transform.position).normalized;
                            //float rangePercent = (1 - Mathf.Clamp((distance / thisOne.range), 0, 1));
                            //print("force = " + (direction * other.mass * rangePercent) + ", Dir: " + direction + ", mass: " + other.mass + ", range: " + rangePercent);
                            //thisOne.rb.AddForce((direction * thisOne.mass * rangePercent) * (framerateMultiplier * Time.deltaTime));
                            //thisOne.rb.AddForce((direction * attraction) * (framerateMultiplier * Time.deltaTime));
                            thisOne.rb.AddForce(direction * attraction);
                            thisOne.rb.velocity = new Vector3(thisOne.rb.velocity.x, 0, thisOne.rb.velocity.z);
                        }
                        if (other != thisOne && other != null)
                        {

                            Vector3 direction = (thisOne.transform.position - other.transform.position).normalized;
                            //float rangePercent = (1 - Mathf.Clamp((distance / other.range), 0, 1));
                            //other.rb.AddForce((direction * thisOne.mass * rangePercent) * (framerateMultiplier * Time.deltaTime));
                            other.rb.AddForce((direction * attraction) * (framerateMultiplier * Time.deltaTime));
                            other.rb.velocity = new Vector3(other.rb.velocity.x, 0, other.rb.velocity.z);
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
        }
    }

    public static float getDistance(MassObject obj1, MassObject obj2)
    {
        if (obj1 == null || obj1.transform == null || obj2 == null || obj2.transform == null) return 0;

        return Vector3.Distance(obj1.transform.position, obj2.transform.position);
    }
    public static float getAttraction(MassObject obj1, MassObject obj2)
    {
        if (obj1 == null || obj1.transform == null || obj2 == null || obj2.transform == null) return 0;

        float distance = getDistance(obj1, obj2);
        return obj1.mass * obj2.mass / (distance * distance);
    }


}
