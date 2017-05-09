//This script is modeled after the Summon script as it summons a trap on the trap zones on the field

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
	public GameObject monster;
	public Camera camera;
	public bool summoned;
	public bool canSummon;

	// Use this foinitialization
	void Start () {
		summoned = false;
		canSummon = false;
        	camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {

	}

	//When you click and release with the mouse, this function would occur to set a trap
	public void OnMouseUp()
	{

		if (canSummon)
		{
			if (!summoned)
			{
				if (camera.ScreenToWorldPoint(Input.mousePosition).x < 0) //placing a trap for player
				{

					Debug.Log("Player Trap");
					GameObject unit = PhotonNetwork.Instantiate("playertrap", this.transform.position, monster.transform.rotation, 0);
					unit.GetComponent<Unit>().master = 1; //Unit is recognized as a player trap
					GameLists.PlayerTrap.Add(unit); //places the player trap in the PlayerTrap game list
					summoned = true; //the boolean would let a trap be summoned on the chosen trap zone
					GameLists.SummonZones.Add(this.gameObject);
					foreach (GameObject zone in GameLists.PlayerTrapSummon)
					{
						//If there is already a trap on a zone, you cannot place a trap on that zone
						Debug.Log(zone.name + "trying to see if false");
						if (zone.GetComponent<Trap>().canSummon)
						{
							zone.GetComponent<Trap>().canSummon = false;
						}
					}
                    			Destroy(GameLists.selectedCard); // destroys the card that deployed the trap on the field
                }
				else //placing a trap for enemy
				{
					Debug.Log("Enemy Trap");
					GameObject unit = PhotonNetwork.Instantiate("enemytrap", this.transform.position, monster.transform.rotation, 0);
					GameLists.EnemyTrap.Add(unit); //places the enemy trap in the EnemyTrap game list
					unit.GetComponent<Unit>().master = 2; //Unit is recognized as an enemy trap
                    summoned = true; //the boolean would let a trap be summoned on the chosen trap zone
                    GameLists.SummonZones.Add(this.gameObject);
                    foreach (GameObject zone in GameLists.PlayerTrapSummon)
                    {
			//If there is already a trap on a zone, you cannot place a trap on that zone
                        Debug.Log(zone.name + "trying to see if false");
                        if (zone.GetComponent<Trap>().canSummon)
                        {
                            zone.GetComponent<Trap>().canSummon = false;
                        }
                    }
                    Destroy(GameLists.selectedCard); // destroys the card that deployed the trap on the field
                }
			}
		}
	}

	//If resets the boolean to false so that a trap can be placed at a trap zone
	public void resetSummon()
	{
		summoned = false;
	}
}
