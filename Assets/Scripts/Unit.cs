using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public int master;
    public int health=1;
    public int movement=1;
    public int movementLeft;
    public int dmg=1;
	// Use this for initialization
	void Start () {
        movementLeft = movement;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void doneMoving()
    {
        movementLeft = movement;
    }
}
