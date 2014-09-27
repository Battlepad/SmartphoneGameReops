using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
//#if UNITY_ANDROID && !UNITY_EDITOR
		
//            if (Input.GetTouch(0).phase == TouchPhase.Began)
            	
//#endif
    }

    void OnMouseDown()
    {
        if (this.gameObject.guiText.enabled == true)
            Application.LoadLevel("Game");
    }
}
