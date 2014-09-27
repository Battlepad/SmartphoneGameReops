using UnityEngine;
using System.Collections;

public enum State
{
    GameOver,
    Paused,
    OnGoing,
    WaitUntilTap,
}

public class GameState {

    private static GameState _instance = null;
    private static State state = State.OnGoing;

    public static GameState Instance
    {
        get
        {
            lock (typeof(GameState))
            {
                if (_instance == null)
                {
                    _instance = new GameState();

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

    public void SetStateToPaused()
    {
        lock (typeof(GameState))
            state = State.Paused;
    }

    public void SetStateToOnGoing()
    {
        lock (typeof(GameState))
            state = State.OnGoing;
    }

    public void SetStateToGameOver()
    {
        lock (typeof(GameState))
            state = State.GameOver;
    }

    public void SetStateToWaitUntilTap()
    {
        lock (typeof(GameState))
            state = State.WaitUntilTap;
    }

    public State GetState()
    {
        return state;
    }
}
