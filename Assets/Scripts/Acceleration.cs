﻿using UnityEngine;
using System.Collections;

public class Acceleration : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<GUIText>().text = Input.acceleration.x.ToString ();
	}
}
