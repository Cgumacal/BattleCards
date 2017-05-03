using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLists : MonoBehaviour {

    public static List<GameObject> PlayerUnits = new List<GameObject>();
    public static List<GameObject> EnemyUnits = new List<GameObject>();
    public static List<GameObject> SummonZones = new List<GameObject>();
    public static List<GameObject> PlayerSummon = new List<GameObject>();
    public static List<GameObject> EnemySummon = new List<GameObject>();
	public static List<GameObject> PlayerTrap = new List<GameObject>();
	public static List<GameObject> PlayerTrapSummon = new List<GameObject>();
	public static List<GameObject> EnemyTrap = new List<GameObject>();
	public static List<GameObject> EnemyTrapSummon = new List<GameObject>();
    public static List<GameObject> Movement = new List<GameObject>();
    public static List<GameObject> DeckPlayer = new List<GameObject>();
    public static List<GameObject> DeckOpponent = new List<GameObject>();
    public static List<GameObject> ToBeInstantiated = new List<GameObject>();
    public List<GameObject> Player = new List<GameObject>();
    public List<GameObject> Enemy = new List<GameObject>();

    public static GameObject selectedCard = null;

    // Use this for initialization
    void Start () {
        Summon[] summon = GameObject.FindObjectsOfType<Summon>();
        foreach (Summon script in summon)
        {
            SummonZones.Add(script.gameObject);
            if (script.gameObject.transform.parent.name.Contains("Player"))
            {
                PlayerSummon.Add(script.gameObject);
                Debug.Log("added " + script.gameObject.name);
            }
            if (script.gameObject.transform.parent.name.Contains("Enemy"))
            {
                EnemySummon.Add(script.gameObject);
            }
        } 

		Trap[] trapSummon = GameObject.FindObjectsOfType<Trap>();
		foreach (Trap script in trapSummon)
		{
			SummonZones.Add(script.gameObject);
			if (script.gameObject.transform.parent.name.Contains("Player"))
			{
				PlayerTrapSummon.Add(script.gameObject);
				Debug.Log("added " + script.gameObject.name);
			}
			if (script.gameObject.transform.parent.name.Contains("Enemy"))
			{
				EnemyTrapSummon.Add(script.gameObject);
			}
		}
	}

    [PunRPC]
    void addPlayer(GameObject x)
    {
        PlayerUnits.Add(x);
    }

    void addEnemy(GameObject x)
    {
        EnemyUnits.Add(x);
    }
	

}
