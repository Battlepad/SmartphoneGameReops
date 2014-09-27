using UnityEngine;
using System.Collections;

public class DataStorage {

    private static DataStorage _instance = null;

    public static DataStorage Instance
    {
        get
        {
            lock (typeof(DataStorage))
            {
                if (_instance == null)
                {
                    _instance = new DataStorage();

                }
                return _instance;
            }
        }
    }

    public static int yCoordinatesFloorDown = -5;
    public static float yCoordinatesFloorUp = 5.5f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetYCoordinatesFloorDown()
    {
        return yCoordinatesFloorDown;
    }

    public float GetYCoordinatesFloorUp()
    {
        return yCoordinatesFloorUp;
    }
}
