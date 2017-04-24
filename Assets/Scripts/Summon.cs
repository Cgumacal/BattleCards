using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void OnMouseUp()
    {

        if (canSummon)
        {
            if (!summoned)
            {
                if (camera.ScreenToWorldPoint(Input.mousePosition).x < 0)
                {
                   
                    Debug.Log("Player Summon");
                    GameObject unit = PhotonNetwork.Instantiate("rightplayer", this.transform.position, monster.transform.rotation, 0);
                    unit.GetComponent<Unit>().master = 1;
                    unit.GetComponent<SpriteRenderer>().sprite = GameLists.selectedCard.GetComponent<Card>().monsterGraphic;
                    GameLists.PlayerUnits.Add(unit);
                    summoned = true;
                    GameLists.SummonZones.Add(this.gameObject);
                    foreach (GameObject zone in GameLists.PlayerSummon)
                    {
                        Debug.Log(zone.name + "trying to see if false");
                        if (zone.GetComponent<Summon>().canSummon)
                        {
                            zone.GetComponent<Summon>().canSummon = false;
                        }
                    }
                    Destroy(GameLists.selectedCard);
                    GameLists.selectedCard = null;
                }
                else
                {
                    Debug.Log("Enemy Summon");
                    GameObject unit = PhotonNetwork.Instantiate("leftplayer", this.transform.position, monster.transform.rotation, 0);
                    GameLists.EnemyUnits.Add(unit);
                    unit.GetComponent<Unit>().master = 2;
                    summoned = true;
                    //EndTurn.SummonZones.Add(this.gameObject);
                    //Debug.Log(camera.ScreenToWorldPoint(Input.mousePosition));
                    foreach (GameObject zone in GameLists.EnemySummon)
                    {
                        Debug.Log(zone.name + "trying to see if false");
                        if (zone.GetComponent<Summon>().canSummon)
                        {
                            zone.GetComponent<Summon>().canSummon = false;
                        }
                    }
                    Destroy(GameLists.selectedCard);
                    GameLists.selectedCard = null;
                }
            }
        }
    }
    public void resetSummon()
    {
        summoned = false;
    }

}
