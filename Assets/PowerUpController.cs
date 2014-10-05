using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

    private static bool slowMotionActive = false;
    private static bool slowMotionAvailable = false;

    private static PowerUpController _instance = null;
    private static GameObject carrierObject = null;

    private static  float time = 0;

    public static PowerUpController Instance
    {
        get
        {
            if (_instance == null)
            {
                carrierObject = new GameObject("PowerUpController");
                _instance = carrierObject.AddComponent<PowerUpController>();
            }
            return _instance;
        }
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (slowMotionActive)
        {
            if(time == 0)
                time = Time.time;
            else if (Time.time >= time + 5)
            {
                DeactivateSlowMotion();
                time = 0;
            }
 
        }

	}
    //Slowmotion
    public void ActivateSlowMotion()
    {
        slowMotionActive = true;
        slowMotionAvailable = false;
        PlayerProperties.Instance.SetPlayerSpeedToSlowMotion();
    }

    private void DeactivateSlowMotion()
    {
        slowMotionActive = false;
        PlayerProperties.Instance.SetPlayerSpeedToNormal();
    }

    public bool SlowMotionActive()
    {
        return slowMotionActive;
    }

    public void SetSlowMotionAvailable()
    {
        slowMotionAvailable = true;
    }

    private void SetSlowMotionUnavailable()
    {
        slowMotionAvailable = false;
    }

    public bool SlowMotionAvailable()
    {
        return slowMotionAvailable;
    }
}
