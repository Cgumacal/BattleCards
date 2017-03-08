using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneList : MonoBehaviour {
    public static List<GameObject> PlayerSummon = new List<GameObject>();
    public static List<GameObject> EnemySummon = new List<GameObject>();
    // Use this for initialization
    void Start () {
        Summon[] summon = GameObject.FindObjectsOfType<Summon>();
        foreach (Summon script in summon)
        {
            if (script.gameObject.transform.parent.name.Contains("Player"))
            {
                PlayerSummon.Add(script.gameObject);
                Debug.Log("added " + script.gameObject.name);
            }
            if (script.gameObject.transform.parent.name.Contains("Player"))
            {
                EnemySummon.Add(script.gameObject);
            }
        }  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
