using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;


public class RandomMatchmaking : Photon.PunBehaviour {
	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
	void OnGUI () {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

    public void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Player>().playerID = 2;

    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("cant join room creating one now");
        RoomOptions roomOptions = new global::RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, roomOptions, null);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerID = 1;
    }

    /*public void OnJoinedRoom()
    {
        Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerID);
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerID == 1) {
            PhotonNetwork.Instantiate("ListSystem", Vector3.zero, Quaternion.identity, 0);
        }
    }*/
}
