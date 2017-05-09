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
    
    //A card display with this method would enable the user to select a unit/monster card
    public void selectCard()
    {
        Debug.Log("mouse as button up working");
        GameLists.selectedCard = this.gameObject; //makes sure that the selected card is being referenced

        if (manaCost <= EndTurn.ownedPlayer.GetComponent<Player>().mana) //checks to see if the player has sufficient mana to play the selected card
        {
            if (playerID == 1) //if it's player 1, the left side, or "player side" of the board enables zones to be selected to summon the unit from the selected card
            {
                foreach (GameObject zone in GameLists.PlayerSummon) //loops through each of the "player" zones
                {
                    Debug.Log(zone.name + "trying to see if true");
                    if (!zone.GetComponent<Summon>().canSummon) zone.GetComponent<Summon>().canSummon = true; //sets the "player" summon zones to allow a unit to be summoned
                }
            }
            else //if player id is not 1, the right side, or the "enemy side" of the board enables zones to be selected to summon the unit from the selected card
            {
                foreach (GameObject zone in GameLists.EnemySummon) //loops through each of the "enemy" summon zones
                {
                    Debug.Log(zone.name + "trying to see if true");
                    if (!zone.GetComponent<Summon>().canSummon) zone.GetComponent<Summon>().canSummon = true; //ests the "enemy" summon ones to allow a unit to be summoned
                }
            }
        }
        else
        {
            Debug.Log("Not enough mana");//error logged if player does not have sufficient mana to play the card
        }
    }

    public void deselectCard() // was supposed to reset all card status so that the player can deselect a card if they desired...this function is still being debugged
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

    //A card display with this method would enable the user to select a trap card
    public void selectTrapCard()
    {
        //sets the boolean canSummon in Trap script as true as a trap can be summoned on the field
        Debug.Log("mouse as button up working");
        foreach (GameObject zone in GameLists.PlayerTrapSummon)
        {
            Debug.Log(zone.name + "trying to see if true");
            if (!zone.GetComponent<Trap>().canSummon)
                zone.GetComponent<Trap>().canSummon = true;
        }
    }
}