using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelfDestroy : MonoBehaviour {

    private bool destroy = false;
    private float beginningTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(destroy)
        {
            if(beginningTime == 0)
                beginningTime = Time.time;
            if (Time.time >= beginningTime + 3)
            {
                List<GameObject> children = new List<GameObject>();
                foreach (Transform child in transform) 
                    children.Add(child.gameObject);
                children.ForEach(child => Destroy(child));
                Destroy(this.gameObject);
            }
    }
	}

    public void Destroy()
    {
        destroy = true;
    }
}
