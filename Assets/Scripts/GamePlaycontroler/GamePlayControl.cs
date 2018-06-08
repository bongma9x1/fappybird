using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayControl : MonoBehaviour {
    public static GamePlayControl instance;

    [SerializeField]
    private Button instructionButton;
    [SerializeField]
    private Text scoreText,endScoretext, bestScore;
    [SerializeField]
    private GameObject gameOverPanel;
    void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
    }
    void _MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void _InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void _banerOver(int score)
    {
        gameOverPanel.SetActive(true);
        endScoretext.text = "" + score;
        if(score > GameManager1.instance._getHighScore())
        {
            GameManager1.instance._setHighScore(score);
        }
        bestScore.text = "" + GameManager1.instance._getHighScore();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void _setScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void _againButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
