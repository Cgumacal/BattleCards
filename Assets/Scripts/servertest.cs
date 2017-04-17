using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class servertest : MonoBehaviour {

    public GameObject Card;
    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void summon()
    {
        if(player.GetComponent<Player>().playerID == 1)
        {
            GameObject x = PhotonNetwork.Instantiate("rightplayer", new Vector3(5, 0, 0), Quaternion.identity, 0);

            GameObject.FindGameObjectWithTag("Finish").GetComponent<PhotonView>().RPC("addPlayer", PhotonTargets.All, x);
            //GameObject.FindGameObjectWithTag("Finish").GetComponent<GameLists>().Player.Add(x);
        }else if (player.GetComponent<Player>().playerID == 2)
        {
            GameObject x = PhotonNetwork.Instantiate("rightplayer", new Vector3(-5, 0, 0), Quaternion.identity, 0);
            //GameObject.FindGameObjectWithTag("Finish").GetComponent<GameLists>().Enemy.Add(x);
            GameObject.FindGameObjectWithTag("Finish").GetComponent<PhotonView>().RPC("addEnemy", PhotonTargets.All, x);

        }
    }

    [PunRPC]
    void addPlayer(GameObject x)
    {
        GameLists.PlayerUnits.Add(x);
    }

    void addEnemy(GameObject x)
    {
        GameLists.EnemyUnits.Add(x);
    }
}
