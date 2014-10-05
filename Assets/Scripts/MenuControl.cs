using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {

    public GameObject gameOverMenu = null;
    public GameObject tapToBegin = null;
    public GameObject slowMotion = null;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //Gamestates
        if (GameState.Instance.GetState() == State.GameOver)
		{
            gameOverMenu.SetActive(true); // TODO: only once
			//Debug.Log ("State GameOver");
			//GUIText[] components = gameOverMenu.GetComponentsInChildren<Tex>();
			//foreach(GUIText guiText in components)
				//guiText.enabled = true;
			//gameOverMenu.guiText.enabled = false;
            //gameOverMenu.SetActive(true);
		}
        if (GameState.Instance.GetState() == State.OnGoing) 
		{
            gameOverMenu.SetActive(false); // TODO: only once
			//GUIText[] components = gameOverMenu.GetComponentsInChildren<GUIText>();
			//foreach(GUIText guiText in components)
				//guiText.enabled = false;
			//gameOverMenu.guiText.enabled = true;
            //gameOverMenu.SetActive(false);
		}

        if (GameState.Instance.GetState() == State.WaitUntilTap)
        {
            tapToBegin.SetActive(true);
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                GameState.Instance.SetStateToOnGoing();
                tapToBegin.SetActive(false);
            }
#else
            if (Input.anyKey)
            {
                GameState.Instance.SetStateToOnGoing();
                tapToBegin.SetActive(false);
            }
#endif
        }

        //Powerups
        if (PowerUpController.Instance.SlowMotionAvailable())
            slowMotion.SetActive(true);
        else
            slowMotion.SetActive(false);
            //Deactivate
        //if(slowMotion.
	}
}
