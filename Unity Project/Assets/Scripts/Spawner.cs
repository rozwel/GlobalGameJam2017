using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public static Transform centerStar;

    const float maxRadians = Mathf.PI * 2;

    public GameObject[] asteroidPrefabs;
    public Mesh[] asteroidSkins;
    public int asteroidCount = 1;
    public int innerLimit = 50;
    public int outerLimit = 100;
    public int maxMass = 10;
    public float scaleMultiplier = 1;


    // Use this for initialization
    void Start () {
        centerStar = GameObject.FindGameObjectWithTag("Star").transform;
        for (int i = 0; i < asteroidCount; i++)
        {
            SpawnObject(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnObject(int count)
    {
        var distance = Random.Range(innerLimit, outerLimit);
        var mass = Random.Range(0.1f, maxMass);
        var radAngle = Random.Range(0, maxRadians);
        var speed = Random.Range(20f, 40f);

        var randObjectType = Random.Range(0, asteroidPrefabs.Length);
        var randObjectSkin = Random.Range(0, asteroidSkins.Length);

        var xPosition = centerStar.transform.position.x + distance * Mathf.Cos(radAngle);
        var zPosition = centerStar.transform.position.z + distance * Mathf.Sin(radAngle);
        var yPosition = centerStar.transform.position.y;
        var position = new Vector3(xPosition, yPosition, zPosition);

        var rotation = Random.rotation;

        var newObject = Instantiate(asteroidPrefabs[randObjectType], position, rotation);
        newObject.transform.localScale = newObject.transform.localScale * mass * scaleMultiplier;
        //newObject.GetComponent<MeshFilter>().mesh = asteroidSkins[randObjectSkin];
        newObject.GetComponent<MeshFilter>().mesh = asteroidSkins[count% asteroidSkins.Length];

        var mObj = newObject.GetComponent<MassObject>();
        mObj.velocity = 0*(1f/distance);
        mObj.mass *= mass;

        //var rb = newObject.GetComponent<Rigidbody>();

        //var attraction = MassController.getAttraction(centerStar.GetComponent<MassObject>(), mObj);
        //var xVelocity = attraction * Mathf.Cos(radTang);
        //var zVelocity = attraction * Mathf.Sin(radTang);
        //var yVelocity = 0;
        //var velocity = new Vector3(xVelocity, yVelocity, zVelocity);

        //rb.AddForce(velocity*attraction);
    }

}
