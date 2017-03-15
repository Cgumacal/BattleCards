using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger2DEnter : MonoBehaviour {
	public GameObject winnerPanel;
	public GameObject loserPanel;
	public GameObject drawPanel;

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
			EndTurn.EnemyUnits.Remove (col.gameObject);
			EndTurn.PlayerUnits.Remove (col.gameObject);
			GetComponent<Unit>().health -= col.gameObject.GetComponent<Unit>().dmg;

			if ((col.gameObject.name.Contains ("leftplayer") && GetComponent<Unit> ().health <= 0)
				&& (col.gameObject.name.Contains ("rightplayer") && GetComponent<Unit> ().health <= 0)) {
				drawPanel.SetActive (true);
			}
			else if (col.gameObject.name.Contains ("leftplayer") && GetComponent<Unit> ().health <= 0) {
				loserPanel.SetActive (true);
			} 
			else if (col.gameObject.name.Contains ("rightplayer") && GetComponent<Unit> ().health <= 0) {
				winnerPanel.SetActive (true);
			}

			Destroy (col.gameObject);
		}

	}

}
