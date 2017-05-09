using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        //Application.LoadLevel("Main Menu");
    }

    public void ToDeckEditor()
    {
        SceneManager.LoadScene("Deck Editor");
    }

    public void ToPlay()
    {
        SceneManager.LoadScene("Matchmaking");
    }

    public void ToLogin()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
