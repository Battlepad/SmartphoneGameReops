using UnityEngine;
using System.Collections;

public class DirectToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (this.gameObject.guiText.enabled == true)
            Application.LoadLevel("Menu");
    }
}
