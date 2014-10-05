using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    private bool space = true;

    public float playerSpeed = 0;
    public float sensitivity = 0;

    private int achievementCounter = 0;

    private bool possibleSwipe = false;
    private float touchBegin = 0;
    private float beginOfTouchTime = 0;

    public GameObject score = null;
    public GameObject debugGUI = null;
    public GameObject achievementAudioSource = null;

	// Use this for initialization
	void Start () {
        GameState.Instance.SetStateToWaitUntilTap();
        Destroy(GameObject.Find("AudioMenu"));
        this.GetComponent<CharacterController>().detectCollisions = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (GameState.Instance.GetState() == State.OnGoing)
        {
            //this.GetComponent<CharacterController>().detectCollisions = false;
            this.GetComponent<CharacterController>().Move(new Vector2(PlayerProperties.Instance.GetPlayerSpeed(), 0));
            Debug.Log(PlayerProperties.Instance.GetPlayerSpeed());
#if UNITY_ANDROID && !UNITY_EDITOR
            this.GetComponent<CharacterController>().Move(new Vector2(0, -Input.acceleration.x * sensitivity));
            debugGUI.guiText.text = Input.acceleration.x.ToString();
            if(Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    Debug.Log("Touch began at: " + Input.touches[0].position.y);
                    touchBegin = Input.touches[0].position.y;
                    beginOfTouchTime = Time.time;
                }
                if (Input.touches[0].phase == TouchPhase.Ended && Mathf.Abs(touchBegin - Input.touches[0].position.y) >= Screen.height / 6 && Time.time - beginOfTouchTime <= 0.2f )
                {
                    Debug.Log("Touch ended at: " + Input.touches[0].position.y + " and time: " + (Time.time - beginOfTouchTime));
                    if(touchBegin - Input.touches[0].position.y < 0)
                        this.GetComponent<CharacterController>().Move(new Vector2(0, 1));
                    if(touchBegin - Input.touches[0].position.y > 0)
                        this.GetComponent<CharacterController>().Move(new Vector2(0, -1));
                    beginOfTouchTime = 0;
                }
            }
#else
            if (Input.GetKey(KeyCode.UpArrow))
                this.GetComponent<CharacterController>().Move(new Vector2(0,0.1f));
            if(Input.GetKey(KeyCode.DownArrow))
                this.GetComponent<CharacterController>().Move(new Vector2(0,-0.1f));
            if (Input.GetKey(KeyCode.Space) && space)
            {
                space = false;
                this.GetComponent<CharacterController>().Move(new Vector2(0, 1));
            }
#endif
        }
        if (Input.GetKeyDown(KeyCode.Escape)) //TODO: in eigene Klasse packen
            Application.Quit();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.name.Contains("ScoreRegister"))
        {
            hit.gameObject.GetComponentInParent<SelfDestroy>().Destroy();
            Destroy(hit.gameObject);

            int value = int.Parse(score.GetComponent<Text>().text);
            value = value + 10;
            score.GetComponent<Text>().text = value.ToString();

            achievementCounter++;
            if (achievementCounter == 10)
            {
                achievementAudioSource.GetComponent<AchievementSoundController>().PlaySound();
                achievementCounter = 0;
            }
        }

        if (hit.gameObject.name.Contains("PowerupTime"))
        {
            Debug.Log("hit: " + hit.gameObject.name);
            PowerUpController.Instance.SetSlowMotionAvailable();
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.name.Contains("Obstacle"))
        {
            GameState.Instance.SetStateToGameOver();

            Debug.LogError(hit.gameObject.name);
            
            CheckHighscore();
        }
    }

    void CheckHighscore()
    {
        int currentHighscore = 0;
        if (PlayerPrefs.GetInt("FirstHighscore") != 0)
            currentHighscore = PlayerPrefs.GetInt("FirstHighscore");

        int secondHighscore = 0;
        if (PlayerPrefs.GetInt("SecondHighscore") != 0)
            secondHighscore = PlayerPrefs.GetInt("SecondHighscore");

        int thirdHighscore = 0;
        if (PlayerPrefs.GetInt("ThirdHighscore") != 0)
            thirdHighscore = PlayerPrefs.GetInt("ThirdHighscore");

        if (int.Parse(score.GetComponent<Text>().text) > currentHighscore) //Insert new Highscore and shift the other ones down
        {
            PlayerPrefs.SetInt("FirstHighscore", int.Parse(score.GetComponent<Text>().text));
            PlayerPrefs.SetInt("SecondHighscore", currentHighscore);
            PlayerPrefs.SetInt("ThirdHighscore", secondHighscore);
        }
        else if (int.Parse(score.GetComponent<Text>().text) > secondHighscore)
        {
            PlayerPrefs.SetInt("SecondHighscore", int.Parse(score.GetComponent<Text>().text));
            PlayerPrefs.SetInt("ThirdHighscore", secondHighscore);
        }
        else if (int.Parse(score.GetComponent<Text>().text) > thirdHighscore)
            PlayerPrefs.SetInt("ThirdHighscore", int.Parse(score.GetComponent<Text>().text));

        PlayerPrefs.Save();
    }

}
