using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour{
    public static List<GameObject> PlayerUnits;
    public static List<GameObject> EnemyUnits;
    public static List<GameObject> SummonZones;
	
    void Start()
    {
        PlayerUnits = new List<GameObject>();
        EnemyUnits = new List<GameObject>();
        SummonZones = new List<GameObject>();
    }

    public void endTurn()
    {
        foreach (GameObject x in PlayerUnits)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(1, 0),0.64f * x.GetComponent<Unit>().movement);
            //if(hit && hit.transform.GetComponent<Unit>().master != 1)
            x.transform.position = new Vector3(x.transform.position.x + (0.64f * x.GetComponent<Unit>().movement), x.transform.position.y, x.transform.position.z);
        }
        foreach (GameObject x in EnemyUnits)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.64f * x.GetComponent<Unit>().movement);
            x.transform.position = new Vector3(x.transform.position.x - (0.64f * x.GetComponent<Unit>().movement), x.transform.position.y, x.transform.position.z);
        }
        foreach (GameObject x in SummonZones)
        {
            x.GetComponent<Summon>().resetSummon();
        }
        SummonZones.Clear();
        
    }

    public void summon()
    {
        foreach(GameObject x in ZoneList.PlayerSummon)
        {
            x.GetComponent<Summon>().canSummon = true;
        }
    }
}
