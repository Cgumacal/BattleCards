//This script is for the traps on the game field, it would destroy the trap and unit
//if the unit lands on the trap.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger2DEnter : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Unit collides with the trap and both unit and trap get destroyed
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);

		//If enemy unit steps on player's trap
		if ((col.gameObject.GetComponent<Unit>().master != 1) && (this.gameObject.name.Contains("playertrap")))
        {
			GameLists.EnemyUnits.Remove(col.gameObject); //remove enemy unit from list
            Destroy(col.gameObject); //destroys enemy unit
			GameLists.PlayerTrap.Remove(this.gameObject); //remove player trap from list
			Destroy(this.gameObject); //destroys the trap that was stepped on
        }

		//If player unit steps on enemy's trap
		else if ((col.gameObject.GetComponent<Unit>().master != 2) && (this.gameObject.name.Contains("enemytrap")))
		{
			GameLists.PlayerUnits.Remove(col.gameObject); //remove player unit from list
			Destroy(col.gameObject); //destroys player unit
			GameLists.EnemyTrap.Remove(this.gameObject); //remove enemy trap from list
			Destroy(this.gameObject); //destroys the trap that was stepped on
		}

    }

}
