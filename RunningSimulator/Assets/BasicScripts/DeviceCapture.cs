using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour {

	public GameObject player;
	private PhotonView myPhotonView; //create this photonView Object

	//***********************************************************************************
	//*                        Initilization for Event Handler                                *                                                
	//***********************************************************************************

	void OnJoinedRoom()
	{
		myPhotonView =this.GetComponent<PhotonView>(); //reference photonview in this gameobject
	}


	void Start () {

	}

	void Update () {
		if (Input.touchCount > 0) {
			PressedScreen();
		}
	}

	//***********************************************************************************
	//                                    Event Methods                                     *
	//***********************************************************************************

	public void PressedScreen(){
			this.myPhotonView.RPC("Punch", PhotonTargets.All); //All players see this update with photonView
	}

	//***********************************************************************************
	//                                       RPC Calls                                        *
	//***********************************************************************************

	[PunRPC]
	public void Punch(){
		//Customer.GetComponentInChildren<TVScript> ().TurnOnTv ();
		player.GetComponent<HockeyStick>().punch();
		Debug.Log("Punched!");
	}
}
