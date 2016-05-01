using UnityEngine;
using System.Collections;

public class GetRunTracking : MonoBehaviour {

	public GameObject Player;
	public GameObject playerGameTrak;
	private bool canBounds = true;


	private PhotonView myPhotonView; //create this photonView Object

	void Update () {
		if (playerGameTrak.gameObject.transform.position.y < 0.3f) {
			canBounds = false;
		} else {
			canBounds = true;
		}

		if (0.5f < playerGameTrak.gameObject.transform.position.x || playerGameTrak.gameObject.transform.position.x < -0.5f) {
			if (canBounds) {
				OutOfBounds ();
			}
		} else if (playerGameTrak.gameObject.transform.position.z > -.4f || playerGameTrak.gameObject.transform.position.z < -.85f) {
			if (canBounds) {
				OutOfBounds ();
			}
		}
	}

	public void OutOfBounds(){
		this.myPhotonView.RPC("Rumble", PhotonTargets.All);
	}

	//***********************************************************************************
	//*                        Initilization for Event Handler                                *                                                
	//***********************************************************************************

	void OnJoinedRoom()
	{
		myPhotonView =this.GetComponent<PhotonView>(); //reference photonview in this gameobject
	}
		
	//***********************************************************************************
	//                                       RPC Calls                                        *
	//***********************************************************************************

	[PunRPC]
	public void Run(){
		//Customer.GetComponentInChildren<TVScript> ().TurnOnTv ();
		Player.GetComponent<MovePlayer>().Run();
		Debug.Log("Run");
	}

	[PunRPC]
	public void Rumble(){

	}
}
