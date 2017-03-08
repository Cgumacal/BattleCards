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
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("cant join room creating one now");
        PhotonNetwork.CreateRoom(null);
    }
}
