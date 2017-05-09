using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    //unit class that holds the values for movement, health, dmg, and master
    public string unitName;
    public int master;//which player the unit belongs too
    public int health=1;//how much damage the unit can take before dying
    public int movement=1;//how many spaces the unit can move before it stops 
    public int movementLeft;//used by endturn to move the unit 1 space at a time 
    public int dmg=1;//how much damage the unit does to other units in battle and to the opposing king
	// Use this for initialization
	void Start () {
        movementLeft = movement;//movementLeft is by default equal to the max movement 
	}

    public void doneMoving()
    {
        movementLeft = movement;//resets movement left at the end of the endturn phase
    }
}
