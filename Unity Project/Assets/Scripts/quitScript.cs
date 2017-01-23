using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class quitScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button creditsText;
    public Button exitText;

	// Use this for initialization
	void Start ()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        creditsText = creditsText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;

	}
	
	public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        creditsText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        creditsText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
