using UnityEngine;
using System.Collections;

public class Initialization : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
