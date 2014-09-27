using UnityEngine;
using System.Collections;

public class AchievementSoundController : MonoBehaviour {

    public AudioClip amazing1 = null;
    public AudioClip amazing2 = null;
    public AudioClip incredible = null;
    public AudioClip outstanding = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySound()
    {
        float randomFloat = Random.Range(0f, 1f);

        if(randomFloat >= 0f && randomFloat < 0.25f)
        {
            audio.clip = amazing1;
        }
        else if(randomFloat >= 0.25f && randomFloat < 0.5f)
        {
            audio.clip = amazing2;
        }

        else if(randomFloat >= 0.5f && randomFloat < 0.75f)
        {
            audio.clip = incredible;
        }

        else if(randomFloat >= 0.75f && randomFloat <= 1f)
        {
            audio.clip = outstanding;
        }
        audio.Play();
    }
}
