using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void ToDeckEditor()
    {

    }

    public void ToPlay()
    {
        Application.LoadLevel("MVP");
    }

    public void ToLogin()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
