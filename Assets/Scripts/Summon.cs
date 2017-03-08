using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour {
    public GameObject monster;
    public Camera camera;
    public bool summoned;
    private Vector3 mouse_position, world_position;
    float distance = 10f;

    // Use this foinitialization
    void Start () {
        summoned = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        mouse_position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

        world_position = camera.ScreenToWorldPoint(mouse_position);
        
        Debug.Log("x = " + world_position.x + " y = " + world_position.y+" z = "+mouse_position.z);
        
	}

    public void OnMouseUp()
    {
        if (!summoned)
        {
            if (world_position.x < 0)
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
    public void resetSummon()
    {
        summoned = false;
    }
}
