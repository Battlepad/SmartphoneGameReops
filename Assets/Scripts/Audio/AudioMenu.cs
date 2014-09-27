using UnityEngine;
using System.Collections;

public class AudioMenu : MonoBehaviour {

    public static AudioMenu _instance = null;
    public static AudioMenu Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}

    public void Star()
    {
        Debug.Log("STAR");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
