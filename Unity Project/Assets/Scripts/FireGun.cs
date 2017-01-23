using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {
    public GameObject projectile;
    public float speed = 3f;
    public float life = 2f;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            GameObject go = (GameObject)GameObject.Instantiate(projectile,transform.position,Quaternion.identity);
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Mathf.Abs(35);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 direct = (worldPos - transform.position).normalized * 180;
            direct.y = direct.z;
            worldPos.y = worldPos.z;
            go.transform.LookAt(worldPos);// localEulerAngles = direct + Camera.main.transform.eulerAngles;
            go.transform.localEulerAngles += new Vector3(0, -90, 0);
            go.transform.localEulerAngles = new Vector3(0, go.transform.localEulerAngles.y, 0);
            go.GetComponent<Rigidbody>().velocity = go.transform.TransformDirection(new Vector3(speed, 0, 0));
            Destroy(go, life);
        }
	}
}
