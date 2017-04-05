using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string name;
    public int manaCost;
    // Use this for initialization

    void Start()
    {
        name = null;
        manaCost = 0;
        Debug.Log(" card start");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void selectCard()
    {
        Debug.Log("mouse as button up working");
        foreach (GameObject zone in GameLists.PlayerSummon)
        {
            Debug.Log(zone.name + "trying to see if true");
            if (!zone.GetComponent<Summon>().canSummon) zone.GetComponent<Summon>().canSummon = true;
        }
    }
}