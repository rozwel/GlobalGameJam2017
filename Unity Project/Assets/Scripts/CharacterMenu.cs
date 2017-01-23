using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {

    public Canvas characters, credits, exit, start;
   
    public static bool CarolIsCharacter = false;
   
    // Use this for initialization
   
    public  void SetCharacterSelect(bool val)
    {
        characters.enabled = val;
    }

    public void SetCreditsSelect(bool val)
    {
        credits.gameObject.SetActive(val);
        start.gameObject.SetActive(!val);
    }
    public void SetExitSelect(bool val)
    {
        exit.enabled = val;
    }
    public void CarolPress()
    {
        CarolIsCharacter = true;
        Application.LoadLevel(1);
    }

    public void SpackJarrowPress()
    {
        CarolIsCharacter = false;
        Application.LoadLevel(1);
    }


}
