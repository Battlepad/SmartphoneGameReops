using UnityEngine;
using System.Collections;

public class PlayerProperties //: MonoBehaviour
{
    private float playerSpeed = 0.1f;

    private static PlayerProperties _instance = null;
    //private static GameObject carrierObject = null;

    public static PlayerProperties Instance
    {
        get
        {
            lock (typeof(PlayerProperties))
            {
                if (_instance == null)
                {
                    //carrierObject = new GameObject("CarrierObject");
                    _instance = new PlayerProperties();
                }
                return _instance;
            }
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetPlayerSpeedToSlowMotion()
    {
        lock(typeof(PlayerProperties))
            playerSpeed = 0.05f;
    }

    public void SetPlayerSpeedToNormal()
    {
        lock (typeof(PlayerProperties))
            playerSpeed = 0.1f;
    }

    public float GetPlayerSpeed()
    {
        return playerSpeed;
    }
}
