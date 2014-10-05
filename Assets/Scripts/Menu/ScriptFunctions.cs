using UnityEngine;
using System.Collections;

public class ScriptFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoToStart()
    {
        Application.LoadLevel("Game");
    }

    public void GoToHighscore()
    {
        Application.LoadLevel("Highscore");
    }

    public void GoToOptions()
    {
    }

    public void GoToExit()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Application.LoadLevel("Menu");
    }
}
