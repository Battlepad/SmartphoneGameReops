using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscoreFetcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text[] highscores = GetComponentsInChildren<Text>();
        foreach (Text nameOfChild in highscores)
        {
            if (nameOfChild.text.Contains("Highscore1"))
                nameOfChild.text = "1. " + PlayerPrefs.GetInt("FirstHighscore");
            if (nameOfChild.text.Contains("Highscore2"))
                nameOfChild.text = "2. " + PlayerPrefs.GetInt("SecondHighscore");
            if (nameOfChild.text.Contains("Highscore3"))
                nameOfChild.text = "3. " + PlayerPrefs.GetInt("ThirdHighscore");
               
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
