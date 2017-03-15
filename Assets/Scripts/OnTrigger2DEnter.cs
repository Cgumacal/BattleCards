using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger2DEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Player unit collides with the king and gets destroyed
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log (col.gameObject.name);

		if (col.gameObject.name.Contains("player")) {
			GameLists.EnemyUnits.Remove (col.gameObject);
			GameLists.PlayerUnits.Remove (col.gameObject);
			Destroy (col.gameObject);
			GetComponent<Unit>().health -= col.gameObject.GetComponent<Unit>().dmg;
		}

	}

}
