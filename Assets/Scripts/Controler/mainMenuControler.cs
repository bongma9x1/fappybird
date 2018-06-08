using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuControler : MonoBehaviour {

	// Use this for initialization
    public void _playButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
