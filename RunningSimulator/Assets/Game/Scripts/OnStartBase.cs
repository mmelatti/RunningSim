using UnityEngine;
using System.Collections;

public class OnStartBase : MonoBehaviour {

	public GameObject CardboardMain;

	const string VERSION = "v0.0.1";

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void Start () {
		PhotonNetwork.ConnectUsingSettings (VERSION);
		if (PlayerPrefs.GetString ("Camera") == "mainCamera") {
			CardboardMain.GetComponent<Cardboard>().VRModeEnabled = false;
		}
	}//end of Start() Method

	void OnJoinedLobby(){
		RoomOptions roomOptions = new RoomOptions() { isVisible = true, maxPlayers = 3 };
		PhotonNetwork.JoinOrCreateRoom("Main", roomOptions, TypedLobby.Default);
	}

	void OnPhotonJoinRoomFailed(){
		Debug.Log ("OnPhotonJoinRoomFailed()");
	}

	void OnJoinedRoom(){
		Debug.Log ("OnJoinedRoom");
		//PhotonNetwork.Instantiate ("NetworkPlayer", Vector3.zero, Quaternion.identity, 0);
	}
}
