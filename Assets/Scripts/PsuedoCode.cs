using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsuedoCode : MonoBehaviour {

	/*
Gameplay mockup 
    
    Player Draws 2 cards 
        if deck has less than 5 cards shuffle deck with graveyard 

    Get player selected card 
        if unit 
            get player selected row 
            add summon to list of commands
            subtract cost from current mana 
        else if spell 
            if effects game board 
                get selected target 
                resolve card effect
                subtract cost from current mana 
            else 
                resolve card effect 
                subtract card from current mana
        else if trap
            get selected target space 
            add trap to list of commands 
            subtract cost from current mana 

   player ends turn 
        resolve all commands
            summon unit in selected space 
            set trap on selected panel 

    Resolve unit movements 
        if movement is stopped
            Battle 
                Take health from enemy equal to unit atk power 
                Take health from your unit equal to enemy atk power 
                if your health or enemy health less than or equal to 0 
                    destroy monster whos health is <= 0 
            if one unit dies resolve final movement 
        itterate through monsters and resolve all effects 

                        
     
    
 







     * */
}
