using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpawner : MonoBehaviour {
    public static Transform centerStar;

    const float maxRadians = Mathf.PI * 2;

    public GameObject windPrefab;
    public int rayCount = 36;


    // Use this for initialization
    void Start () {
        centerStar = GameObject.FindGameObjectWithTag("Star").transform;
        var step = 360f / rayCount;
        for (int i = 0; i < rayCount; i++)
        {
            SpawnObject(i, step);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void flipOrientation(GameObject wind)
    {
        var group = wind.transform.FindChild("WaveGroup");
        group.Rotate(new Vector3(0, 180, 0));
        group.Translate(0, 0, -500);
    }

    private void SpawnObject(int count, float step)
    {

        var position = centerStar.position;

        var rotation = Quaternion.AngleAxis(count*step, Vector3.up);

        var newObject = Instantiate(windPrefab, position, rotation);

        if (count % 2 == 0)
        {
            flipOrientation(newObject);
        }

        //var mObj = newObject.GetComponent<MassObject>();
        //mObj.velocity = 0*(1f/distance);
        //mObj.mass *= mass;

        //var rb = newObject.GetComponent<Rigidbody>();

        //var attraction = MassController.getAttraction(centerStar.GetComponent<MassObject>(), mObj);
        //var xVelocity = attraction * Mathf.Cos(radTang);
        //var zVelocity = attraction * Mathf.Sin(radTang);
        //var yVelocity = 0;
        //var velocity = new Vector3(xVelocity, yVelocity, zVelocity);

        //rb.AddForce(velocity*attraction);
    }

}
