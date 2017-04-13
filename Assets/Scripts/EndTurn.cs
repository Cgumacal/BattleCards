using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    private RaycastHit2D hit;
    private List<GameObject> movement = new List<GameObject>();
    private List<GameObject> doneMoving = new List<GameObject>();
    private List<GameObject> battle = new List<GameObject>();
    //list for units that are in front of the king
    private List<GameObject> kingDamage = new List<GameObject>();
    public GameObject playerKing;
    public GameObject enemyKing;
    public GameObject drawPanel;
    public GameObject winnerPanel;
    public GameObject loserPanel;

    void Start()
    {

    }
    /// <summary>
    /// This function is called after both players hit end turn
    /// </summary>
    public void endTurn()
    {
        magicPhase();

    }
    /// <summary>
    /// applies all of the magic cards that were played 
    /// </summary>
    private void magicPhase()
    {
        //Debug.Log("magic phase");
        movementPhase();
    }

    /// <summary>
    /// Goes through all of the units and then moves them in the correct direction
    /// </summary>
    private void movementPhase()
    {
        //Debug.Log("movementPhase");
        movement = new List<GameObject>();
        doneMoving = new List<GameObject>();
        Unit[] units = FindObjectsOfType<Unit>();
        kingDamage = new List<GameObject>();
        foreach (Unit x in units)
        {
            movement.Add(x.gameObject);
        }

        while (movement.Count > 0)
        {
            foreach (GameObject unit in movement)
            {
                Unit current = unit.GetComponent<Unit>();
                if (current.master == 1)
                {

                    hit = Physics2D.Raycast(unit.transform.position, new Vector2(1, 0), 0.96f);
                    /*if (hit && hit.transform.name.Contains ("king")) {
						enemyKing.GetComponent<Unit> ().health -= current.dmg;
						GameLists.PlayerUnits.Remove(unit);
						movement.Remove(unit);
						Destroy(unit);
					}*/

                    if (hit && hit.transform.name.Contains("king"))
                    {
                        //add unit to kingDamage list
                        kingDamage.Add(unit);
                        Debug.Log(unit.name);
                        doneMoving.Add(unit);
                    }
                    else if (hit && !hit.transform.name.Contains("Zone") && !hit.transform.name.Contains("king") && hit.transform.GetComponent<Unit>().master != current.master || current.movementLeft == 0)
                    {
                        //Debug.Log(Physics2D.Raycast(unit.transform.position, new Vector2(1, 0), 0.96f).transform.name);
                        current.movementLeft = 0;
                        doneMoving.Add(unit);
                        //doneMoving.Add(hit.transform.gameObject);

                    }
                    else
                    {
                        unit.transform.position = new Vector3(unit.transform.position.x + 0.64f, unit.transform.position.y, unit.transform.position.z);
                        current.movementLeft--;
                        if (current.movementLeft < 0)
                        {
                            doneMoving.Add(unit);
                        }

                    }
                }
                else
                {
                    hit = Physics2D.Raycast(unit.transform.position, new Vector2(-1, 0), 0.96f);
                    if (hit && hit.transform.name.Contains("king"))
                    {
                        //add unit to kingDamageList
                        kingDamage.Add(unit);

                        doneMoving.Add(unit);
                    }
                    else if (hit && !hit.transform.name.Contains("Zone") && !hit.transform.name.Contains("king") && hit.transform.GetComponent<Unit>().master != current.master || current.movementLeft == 0)
                    {
                        //Debug.Log(Physics2D.Raycast(unit.transform.position, new Vector2(-1, 0), 0.96f).transform.name);
                        current.movementLeft = 0;
                        doneMoving.Add(unit);
                        //doneMoving.Add(hit.transform.gameObject);

                    }
                    else
                    {
                        unit.transform.position = new Vector3(unit.transform.position.x - 0.64f, unit.transform.position.y, unit.transform.position.z);
                        current.movementLeft--;
                        if (current.movementLeft < 0)
                        {
                            doneMoving.Add(unit);
                        }

                    }
                }
            }
            foreach (GameObject unit in doneMoving)
            {
                unit.GetComponent<Unit>().doneMoving();
                movement.Remove(unit);
            }
        }
        //TODO change this to go through a list and move the pieces one space at a time until they have all moved completely
        //Add all units to a move list
        //while list is not empty
        //if owner = 0 
        //raycast 2 spaces if hit enemy movement = 0
        //add to battle list
        // else move units to the right 
        //else if owner = 1
        //raycast 2 spaces if hit player movement = 0
        //add to battle list 
        //else move units to the left 
        //movement decrement by 1 
        //cycle through list if movement = 0 remove from move list

        Debug.Log("movement ends");
        battlePhase();
    }

    /// <summary>
    /// runs all of the battles for this end phase 
    /// </summary>
    private void battlePhase()
    {
        Debug.Log("battle start");
        battle = new List<GameObject>();
        Unit[] units = FindObjectsOfType<Unit>();
        foreach (Unit unit in units)
        {
            battle.Add(unit.gameObject);
        }

        foreach (GameObject unit in battle)
        {
            if (hit = Physics2D.Raycast(unit.transform.position, new Vector2(1, 0), 0.96f))
            {
                if (hit.transform.name.Contains("Zone") || hit.transform.name.Contains("king"))
                {
                    //do nothing
                }
                else if (unit.GetComponent<Unit>().master != hit.transform.GetComponent<Unit>().master)
                {
                    unit.GetComponent<Unit>().health -= hit.transform.GetComponent<Unit>().dmg;
                    hit.transform.GetComponent<Unit>().health -= unit.transform.GetComponent<Unit>().dmg;
                }

            }
        }

        foreach (Unit x in units)
        {
            if (x.health < 0)
            {
                if (x.master == 1)
                {
                    GameLists.PlayerUnits.Remove(x.gameObject);
                    Destroy(x.gameObject);
                }
                else
                {
                    GameLists.EnemyUnits.Remove(x.gameObject);
                    Destroy(x.gameObject);
                }
            }
        }

        foreach (GameObject x in kingDamage)
        {
            Unit current = x.GetComponent<Unit>();
            if (current.master == 1)
            {
                //do damage to player king
                enemyKing.GetComponent<Unit>().health -= current.dmg;
                //remove from list
                //kingDamage.Remove(x.gameObject);
                //destroy unit
                Destroy(x.gameObject);
            }
            else
            {
                //do damage to player king
                playerKing.GetComponent<Unit>().health -= current.dmg;
                //remove from list
                //kingDamage.Remove(x.gameObject);
                //destroy unit
                Destroy(x.gameObject);
            }
        }

        // king health deduction
        unitAbilityPhase();
    }

    /// <summary>
    /// goes through all of the units and activates each of their abilities. 
    /// </summary>
    private void unitAbilityPhase()
    {
        Unit[] units = FindObjectsOfType<Unit>();
        foreach (Unit unit in units)
        {

        }

        victoryCheck();
    }

    //Checks who won the match or if the match is a draw. Shows a panel on the result of the game
    private void victoryCheck()
    {
        Debug.Log(playerKing.GetComponent<Unit>().health);
        //If both player and enemy end with 0 hp or less at the same time
        if ((playerKing.GetComponent<Unit>().health <= 0) && (enemyKing.GetComponent<Unit>().health <= 0))
        {
            drawPanel.SetActive(true);
        }
        //When player king hp is less than 0
        else if (playerKing.GetComponent<Unit>().health <= 0)
        {
            loserPanel.SetActive(true);
        }
        //When enemy king hp is less than 0
        else if (enemyKing.GetComponent<Unit>().health <= 0)
        {
            winnerPanel.SetActive(true);
        }

        resetPhase();
    }

    private void resetPhase()
    {
        foreach (GameObject x in GameLists.SummonZones)
        {
            x.GetComponent<Summon>().resetSummon();
        }
    }
}
