using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public int playerID;
    public int Health;
    public int maxMana;
    public int mana;
        
        // Use this for initialization
	void Start () {
        playerID = 0;
        Health = 10;
        maxMana = 5;
	}
	
	// Update is called once per frame
	void Update () {
        
            //GetComponent<Text>().text = "PlayerID: " + playerID + "\nHealth: " + Health + "\nMana: " + Mana;
        
        
   }

    public void subtractMana(int x)
    {
        Debug.Log("subtracting mana cost: " + x);
        mana = mana - x;
    }

    public void resetMana()
    {
        mana = maxMana;
    }
}
