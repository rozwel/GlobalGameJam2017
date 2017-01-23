using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoader : MonoBehaviour {
    public GameObject CarolVoice;
    public GameObject SpackVoice;


    // Use this for initialization
    void Start()
    {
        var voice = CharacterMenu.CarolIsCharacter ? CarolVoice : SpackVoice;
        Instantiate(voice, gameObject.transform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
