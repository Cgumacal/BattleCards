using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerlists : MonoBehaviour {
    public int switc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (switc == 1)
        {
            string x = "";
            foreach (GameObject z in GameObject.FindGameObjectWithTag("Finish").GetComponent<GameLists>().Player)
            {
                x = x + "\n" + z.name;
            }
            GetComponent<Text>().text = x;
        }
        else if (switc == 2)
        {
            string x = "";
            foreach (GameObject z in GameObject.FindGameObjectWithTag("Finish").GetComponent<GameLists>().Enemy)
            {
                x = x + z.name;
            }
            GetComponent<Text>().text = x;
        }
    }
}
