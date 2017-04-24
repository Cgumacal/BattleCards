using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int playerID;
    private int playerMana = 10;
    public Sprite monsterGraphic;

    public string name;
    public int manaCost;
    public int health;
    public int attack;
    public int speed;

    public void selectCard()
    {
        Debug.Log("mouse as button up working");
        GameLists.selectedCard = this.gameObject;

        if (manaCost <= playerMana)
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
}