using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour {
    public GameObject monster;
    public Camera camera;
    public bool summoned;
    public bool canSummon;

    // Use this foinitialization
    void Start () {
        summoned = false;
        canSummon = false;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnMouseUp()
    {

        if (canSummon)
        {
            if (!summoned)
            {
                if (camera.ScreenToWorldPoint(Input.mousePosition).x < 0)
                {
                    Debug.Log("Player Summon");
                    GameObject unit = Instantiate<GameObject>(monster, this.transform.position, monster.transform.rotation);
                    unit.GetComponent<Unit>().master = 1;
                    EndTurn.PlayerUnits.Add(unit);
                    summoned = true;
                    EndTurn.SummonZones.Add(this.gameObject);
                }
                else
                {
                    Debug.Log("Enemy Summon");
                    GameObject unit = Instantiate<GameObject>(monster, this.transform.position, monster.transform.rotation);
                    EndTurn.EnemyUnits.Add(unit);
                    unit.GetComponent<Unit>().master = 2;
                    summoned = true;
                    EndTurn.SummonZones.Add(this.gameObject);
                    //Debug.Log(camera.ScreenToWorldPoint(Input.mousePosition));
                }
            }
        }
    }
    public void resetSummon()
    {
        summoned = false;
    }

}
