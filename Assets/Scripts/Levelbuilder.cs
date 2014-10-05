using UnityEngine;
using System.Collections;

public class Levelbuilder : MonoBehaviour {
    
    //Prefabs
    //private static Levelbuilder _instance = null;
    public GameObject oneObstacleWithoutScore = null;
    public GameObject oneObstacle = null;
    public GameObject twoObstacle = null;
    public GameObject floorPrefab = null;
    public GameObject floatingObstacleParent = null;
    public GameObject floatingObstacleChild = null;
    public GameObject powerUpTime = null;

    public GameObject player = null;

    public float minObstacleHeight = 1;
    public float maxObstacleHeight = 15;
    public float minTwoObstacleYOffset = -3;
    public float maxTwoObstacleYOffset = 3;
    //private int obstacleFrequency = 25; //The lower, the more osbtacles
    private float distanceOfOneToTwoObstacles = 4f;

    private bool goAgain = false;

    public float obstacleDistance = 0;

    private Transform recentObstaclePosition = null;

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
        GameObject recentObstacle = Instantiate(oneObstacle, new Vector2(player.transform.position.x + 25, 0), Quaternion.identity) as GameObject;
        recentObstaclePosition = recentObstacle.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x + 25 >= recentObstaclePosition.position.x || goAgain)
        {
            CreateObstacle();
            int randomNoPowerUp = Random.Range(1, 100);
            if (randomNoPowerUp >= 1 && randomNoPowerUp <= 5)
                CreatePowerUp();
        }
        if (player.transform.position.x - floorDown.transform.position.x >= 10 || floorDown == null)
        {
            MoveFloor();
        }

	}

    void CreateObstacle()
    {
        int randomNo01 = Random.Range(1, 100);
        Debug.Log("RandomNo:" + randomNo01);
        //One Obstacle
        if(randomNo01 >= 1 && randomNo01 < 30)
        {
            GameObject recentObstacle = Instantiate(oneObstacle, new Vector2(recentObstaclePosition.position.x + obstacleDistance, DataStorage.Instance.GetYCoordinatesFloorDown()), Quaternion.identity) as GameObject;
            recentObstacle.transform.localScale = new Vector3(1, Random.Range(minObstacleHeight, maxObstacleHeight), 1);
            recentObstaclePosition = recentObstacle.transform;
            if (goAgain)
                goAgain = false;
        }

        //TwoObstacle
        if (randomNo01 >= 30 && randomNo01 < 60)
        {
            GameObject recentObstacle = Instantiate(twoObstacle, new Vector2(recentObstaclePosition.position.x + obstacleDistance, 0), Quaternion.identity) as GameObject;
            recentObstacle.transform.position = new Vector3(recentObstacle.transform.position.x,
                                                               recentObstacle.transform.position.y + Random.Range(minTwoObstacleYOffset, maxTwoObstacleYOffset),
                                                               recentObstacle.transform.position.z);
            recentObstaclePosition = recentObstacle.transform;
            if (goAgain)
                goAgain = false;
        }
        //single Obstacle without score
        if (randomNo01 >= 60 && randomNo01 < 80 && !goAgain)
        {
            GameObject recentObstacle = Instantiate(oneObstacleWithoutScore, new Vector2(recentObstaclePosition.position.x + distanceOfOneToTwoObstacles, Random.Range(0, 2)), Quaternion.identity) as GameObject;
            recentObstacle.transform.position = new Vector3(recentObstacle.transform.position.x,
                                                               recentObstacle.transform.position.y + Random.Range(minTwoObstacleYOffset, maxTwoObstacleYOffset),
                                                               recentObstacle.transform.position.z);
            goAgain = true;
        }

        if (randomNo01 >= 80 && randomNo01 <= 100 && !goAgain)
        {
            GameObject childObject = Instantiate(floatingObstacleChild, new Vector2(0, Random.Range(0, 2)), Quaternion.identity) as GameObject;//Instantiate(floatingObjectParent, new Vector2(recentObstaclePosition.position.x + distanceOfOneToTwoObstacles, Random.Range(0, 2)), Quaternion.identity) as GameObject;
            //Transform temp = recentObstacle.GetComponentInChildren<Transform>();
            //GameObject recentObstacle = 
            //Transform tremp = parentObject.GetComponentInChildren<Transform>();
            //Transform[] temps = parentObject.GetComponentsInChildren<Transform>();
            //foreach (Transform transf in temps)
            //{
            //    if (transf.Equals("FloatingObstacle"))
            //        transf.position = new Vector3(200, 200, 1);

            //}

            //Debug.LogError("parent " + parentObject.transform.position);
            //Debug.Log("child " + recentObstaclePosition.position);
            childObject.transform.position = new Vector3(recentObstaclePosition.position.x,
                                                               0,
                                                               //recentObstaclePosition.position.y + Random.Range(minTwoObstacleYOffset, maxTwoObstacleYOffset),
                                                               recentObstaclePosition.position.z);
            GameObject temp = Instantiate(floatingObstacleParent, new Vector2(0, 0), Quaternion.identity) as GameObject;
            childObject.transform.parent = temp.transform;
            goAgain = true;
        } //TODO: anpassen mit floating osbtacle
    }

    void MoveFloor()
    {
        floorDown.transform.position = new Vector2(player.transform.position.x, DataStorage.Instance.GetYCoordinatesFloorDown());
        floorUp.transform.position = new Vector2(player.transform.position.x, DataStorage.Instance.GetYCoordinatesFloorUp());
    }

    void CreatePowerUp()
    {
        GameObject recentObstacle = Instantiate(powerUpTime, new Vector2(recentObstaclePosition.position.x + obstacleDistance, Random.Range(-3f, 3f)), Quaternion.identity) as GameObject;
        recentObstaclePosition = recentObstacle.transform;
    }


}
