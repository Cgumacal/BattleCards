using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public int playerID;
    public int Health;
    public int Mana;
    public int switc; 
	
        
        // Use this for initialization
	void Start () {
        playerID = 0;
        Health = 10;
        Mana = 5;
	}
	
	// Update is called once per frame
	void Update () {
        
            //GetComponent<Text>().text = "PlayerID: " + playerID + "\nHealth: " + Health + "\nMana: " + Mana;
        
        
   }
}
