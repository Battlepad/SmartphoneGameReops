using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    //private Vector3 velocity = Vector3.zero;
    //public float dampTime = 0.15f;
    public Transform player = null;
    public Transform background = null;
    public int xOffset = 0;
    public int zOffset = 0;

    private float backgroundXPosMultiplier = 0.98f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x + xOffset, 0, zOffset);
        background.position = new Vector3(9 + (player.transform.position.x * backgroundXPosMultiplier), 0, 0);
        //Vector3 point = camera.WorldToViewportPoint(target.position);
        //Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
        //Vector3 destination = transform.position + delta;
        //transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
	}
}
