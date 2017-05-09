using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Summany:
 *  This script is used on the mana bar to continuously
 *  update the bar so that the players current mana is shown.
 */
public class calculateMana : MonoBehaviour {
    //Declare Variables
    Slider manaBar;
    Text manaText;
    
	// Use this for initialization
	void Start () {
        manaBar = this.GetComponent<Slider>();//gets the slider component of this game object 
        manaText = this.GetComponentInChildren<Text>(); //gets the text component in the children of this object 
	}
	
	// Update is called once per frame
	void Update () {
        if (EndTurn.ownedPlayer != null)//once EndTurn.ownedPlayer is initialized
        {
            //get the percentage of mana that is left and change the slider value to match it 
            float value = EndTurn.ownedPlayer.GetComponent<Player>().mana / EndTurn.ownedPlayer.GetComponent<Player>().maxMana;
            manaBar.value = value;
            //Change text to match the actual value of mana the player has left
            manaText.text = EndTurn.ownedPlayer.GetComponent<Player>().mana.ToString();
        }
    }
}
