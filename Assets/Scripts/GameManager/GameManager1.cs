using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour {
    public static GameManager1 instance;

    private const string HIGT_SCORE = "High Score";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Awake () {
        _MakeInstance();
        IsGameStartedForTheFirstTime();
	}
    void _MakeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGT_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }
    public void _setHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGT_SCORE, score);
    }

    public int _getHighScore()
    {
        return PlayerPrefs.GetInt(HIGT_SCORE);
    }
}
