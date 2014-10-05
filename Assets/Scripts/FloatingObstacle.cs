using UnityEngine;
using System.Collections;

public class FloatingObstacle : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;
    private bool moveUp = true;
	// Use this for initialization
	void Start () {
        targetPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {
        if(moveUp)
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.4f);
        if (!moveUp)
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, targetPosition.y - 1, transform.position.z), ref velocity, 0.2f);
        
        if (transform.position == targetPosition)
            moveUp = false;
        if (transform.position == new Vector3(targetPosition.x, targetPosition.y -1, targetPosition.z))
            moveUp = true;

            Debug.Log("done");
        //Debug.Log(transform.position + " " + targetPosition);

	}
}
