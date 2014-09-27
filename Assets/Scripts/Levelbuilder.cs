using UnityEngine;
using System.Collections;

public class Levelbuilder : MonoBehaviour {

    //private static Levelbuilder _instance = null;
    public GameObject oneObstacleWithoutScore = null;
    public GameObject oneObstacle = null;
    public GameObject twoObstacle = null;
    public GameObject floorPrefab = null;
    public GameObject player = null;

    public float minObstacleHeight = 1;
    public float maxObstacleHeight = 15;
    public float minTwoObstacleYOffset = -3;
    public float maxTwoObstacleYOffset = 3;
    //private int obstacleFrequency = 25; //The lower, the more osbtacles
    private float distanceOfOneToTwoObstacles = 4f;

    private bool goAgain = false;

    public float obstacleDistance = 0;

    private GameObject recentObstacle = null;

    private GameObject floorDown = null;
    private GameObject floorUp = null;

    //public static Levelbuilder Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            GameObject gameObject = new GameObject("Levelbuilder");
    //            _instance = gameObject.AddComponent<Levelbuilder>();
    //            DontDestroyOnLoad(gameObject);
    //        }
    //        return _instance;
    //    }
    //}

    public void Init()
    {
        Debug.Log("Levelbuilder initialized");
    }

	// Use this for initialization
	void Start () {
        floorDown = Instantiate(floorPrefab, new Vector2(player.transform.position.x, DataStorage.Instance.GetYCoordinatesFloorDown()), Quaternion.identity) as GameObject;
        floorUp = Instantiate(floorPrefab, new Vector2(player.transform.position.x, DataStorage.Instance.GetYCoordinatesFloorUp()), Quaternion.identity) as GameObject;
        recentObstacle = Instantiate(oneObstacle, new Vector2(player.transform.position.x + 25, 0), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x + 25 >= recentObstacle.transform.position.x || goAgain)
        {
            CreateObstacle();
        }
        if (player.transform.position.x - floorDown.transform.position.x >= 10 || floorDown == null)
        {
            MoveFloor();
        }

	}

    void CreateObstacle()
    {
        float randomNo01 = Random.Range(0f, 1f);
        Debug.Log("RandomNo:" + randomNo01);
        if(randomNo01 >= 0 && randomNo01 < 0.4)
        {
            recentObstacle = Instantiate(oneObstacle, new Vector2(recentObstacle.transform.position.x + obstacleDistance, DataStorage.Instance.GetYCoordinatesFloorDown()), Quaternion.identity) as GameObject;
            recentObstacle.transform.localScale = new Vector3(1, Random.Range(minObstacleHeight, maxObstacleHeight), 1);
            if (goAgain)
                goAgain = false;
        }

        if (randomNo01 >= 0.4 && randomNo01 < 8)
        {
            recentObstacle = Instantiate(twoObstacle, new Vector2(recentObstacle.transform.position.x + obstacleDistance, 0), Quaternion.identity) as GameObject;
            recentObstacle.transform.position = new Vector3(recentObstacle.transform.position.x,
                                                               recentObstacle.transform.position.y + Random.Range(minTwoObstacleYOffset, maxTwoObstacleYOffset),
                                                               recentObstacle.transform.position.z);
            if (goAgain)
                goAgain = false;
        }

        if (randomNo01 >= 0.8 && randomNo01 <= 1 && !goAgain)
        {
            recentObstacle = Instantiate(oneObstacleWithoutScore, new Vector2(recentObstacle.transform.position.x + distanceOfOneToTwoObstacles, Random.Range(0, 2)), Quaternion.identity) as GameObject;
            recentObstacle.transform.position = new Vector3(recentObstacle.transform.position.x,
                                                               recentObstacle.transform.position.y + Random.Range(minTwoObstacleYOffset, maxTwoObstacleYOffset),
                                                               recentObstacle.transform.position.z);
            goAgain = true;
        }
    }

    void MoveFloor()
    {
        floorDown.transform.position = new Vector2(player.transform.position.x, DataStorage.Instance.GetYCoordinatesFloorDown());
        floorUp.transform.position = new Vector2(player.transform.position.x, DataStorage.Instance.GetYCoordinatesFloorUp());
    }
}
