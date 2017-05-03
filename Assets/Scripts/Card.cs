using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int playerID;
    private int playerMana;
    public Sprite monsterGraphic;

    public string name;
    public int manaCost;
    public int health;
    public int attack;
    public int speed;
    private GameObject player;

    void Start()
    {
        player = EndTurn.ownedPlayer;  
    }

    void Update()
    {
        if (PhotonNetwork.isMasterClient)
        {
            playerID = 1;
        }
        else
        {
            playerID = 2;
        }
    }

    public void selectCard()
    {
        Debug.Log("mouse as button up working");
        GameLists.selectedCard = this.gameObject;

        if (manaCost <= player.GetComponent<Player>().mana)
        {
            if (playerID == 1)
            {
                foreach (GameObject zone in GameLists.PlayerSummon)
                {
                    Debug.Log(zone.name + "trying to see if true");
                    if (!zone.GetComponent<Summon>().canSummon) zone.GetComponent<Summon>().canSummon = true;
                }
            }
            else
            {
                foreach (GameObject zone in GameLists.EnemySummon)
                {
                    Debug.Log(zone.name + "trying to see if true");
                    if (!zone.GetComponent<Summon>().canSummon) zone.GetComponent<Summon>().canSummon = true;
                }
            }
        }else
        {
            Debug.Log("Not enough mana");
        }
    }

    public void deselectCard()
    {
        GameLists.selectedCard = this.gameObject;

        if (playerID == 1)
        {
            foreach (GameObject zone in GameLists.PlayerSummon)
            {
                Debug.Log(zone.name + "trying to see if true");
                if (!zone.GetComponent<Summon>().canSummon) zone.GetComponent<Summon>().canSummon = false;
            }
        }
        else
        {
            foreach (GameObject zone in GameLists.EnemySummon)
            {
                Debug.Log(zone.name + "trying to see if true");
                if (!zone.GetComponent<Summon>().canSummon) zone.GetComponent<Summon>().canSummon = false;
            }
        }
    }

	public void selectTrapCard(){
		Debug.Log("mouse as button up working");
		foreach (GameObject zone in GameLists.PlayerTrapSummon)
		{
			Debug.Log(zone.name + "trying to see if true");
			if (!zone.GetComponent<Trap>().canSummon) zone.GetComponent<Trap>().canSummon = true;
		}
	}
}