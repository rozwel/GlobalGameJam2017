using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fps : MonoBehaviour {
    Text thisText;
    void Start()
    {
        thisText = GetComponent<Text>();
        InvokeRepeating("MyUpdate", 1, 1);
    }
	void MyUpdate ()
    {
        thisText.text = "FPS: " + (int)(1.0f / Time.deltaTime);
	}
}
