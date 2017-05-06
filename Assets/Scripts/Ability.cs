using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour 
{
	void effects()
	{
		if (gameObject.name.Contains ("Fallen Angel"))//This ability is for Unit named Fallen angel to heal units close to her 
		{
			Vector2 a = transform.TransformDirection (Vector2.right) * 1;//checks if anything is one square to the right of her
			Debug.DrawRay (transform.position, a, Color.red);
			RaycastHit2D hit1 =Physics2D.Raycast(transform.position, a);

			Vector2 b = transform.TransformDirection (Vector2.left) * 1;//checks if anything is one square to the left of her
			Debug.DrawRay (transform.position, b, Color.red);
			RaycastHit2D hit2 =Physics2D.Raycast(transform.position, b);

			Vector2 c = transform.TransformDirection (Vector2.down) * 1;//checks if anything is one square to the south of her
			Debug.DrawRay (transform.position, c, Color.red);
			RaycastHit2D hit3 =Physics2D.Raycast(transform.position, c);

			Vector2 d = transform.TransformDirection (Vector2.up) * 1;//checks if anything is one square to the north of her
			Debug.DrawRay (transform.position, d, Color.red);
			RaycastHit2D hit4 =Physics2D.Raycast(transform.position, d);

			/*These boolean checks if she has any units around her and if she does, she heals them*/
			if (hit1 != null) 
			{
				if (hit1.collider.gameObject.GetComponent<Unit> ().master == this.gameObject.GetComponent<Unit> ().master)
				{
					hit1.collider.gameObject.GetComponent<Unit> ().health++;
				}
			}
			if (hit2 != null) 
			{
				if (hit2.collider.gameObject.GetComponent<Unit> ().master == this.gameObject.GetComponent<Unit> ().master)
				{
					hit2.collider.gameObject.GetComponent<Unit> ().health++;
				}
			}
			if (hit3 != null) 
			{
				if (hit3.collider.gameObject.GetComponent<Unit> ().master == this.gameObject.GetComponent<Unit> ().master)
				{
					hit3.collider.gameObject.GetComponent<Unit> ().health++;
				}
			}
			if (hit4 != null) 
			{
				if (hit4.collider.gameObject.GetComponent<Unit> ().master == this.gameObject.GetComponent<Unit> ().master)
				{
					hit4.collider.gameObject.GetComponent<Unit> ().health++;
				}
			}
		}
		else if (gameObject.name.Contains ("Berserker"))//Berserker loses health every turn
		{
			this.gameObject.GetComponent<Unit> ().health--;
		}
		else if (gameObject.name.Contains ("Angry Kopy Kat"))//Angry Kopy Kat gains 1 attack each turn
		{
			this.gameObject.GetComponent<Unit> ().dmg++;
		}
		else if (gameObject.name.Contains ("Swift Mimic"))//Swift Mimic gains a movement speed every turn
		{
			this.gameObject.GetComponent<Unit> ().movement++;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
