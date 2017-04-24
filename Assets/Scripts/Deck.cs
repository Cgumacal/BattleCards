using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Deck : MonoBehaviour 
{
	int count=0;
	int indexHand = 1;
	private List<GameObject> card = new List<GameObject>();
	private List<GameObject> hand = new List<GameObject>();
	// Update is called once per frame
	void Update ()
	{
		
	}
	void addCard(GameObject c)
	{
		if (count < 20) 
		{
			card.Add (c);
			count++;
		}
	}
	void shuffleDeck()
	{
		for (var i = 0; i < 1000; i++)
		{
			int cardOne = Random.Range (1, 21);
			int cardTwo = Random.Range (1, 21);
			if (cardOne != cardTwo) 
			{
				var temp = card [cardOne];
				card [cardOne] = card [cardTwo];
				card [cardTwo] = temp;
			}
		}
	}
	void DrawTurn()
	{
		if (card.Count > 5) 
		{
			hand.Add (card [indexHand]);
			indexHand++;
			hand.Add (card [indexHand]);
			indexHand++;
		} 
		else 
		{
			indexHand = 1;
			shuffleDeck ();
			hand.Add (card [indexHand]);
			indexHand++;
			hand.Add (card [indexHand]);
			indexHand++;
		}
	}
}
