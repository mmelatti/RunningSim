using UnityEngine;
using System.Collections;

public class RunTracking : MonoBehaviour {

	//public GameObject Player;

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
		if (Input.acceleration.x > 1.3 || Input.acceleration.y > 1.3 || Input.acceleration.z > 1.3) {
			SingleStride (); 
		} else if (Input.GetKeyDown (KeyCode.L)) {
			SingleStride ();
		}
	}

	//***********************************************************************************
	//                                    Event Methods                                     *
	//***********************************************************************************

	public void SingleStride(){
		this.myPhotonView.RPC("Run", PhotonTargets.All); //All players see this update with photonView
	}

	//***********************************************************************************
	//                                       RPC Calls                                        *
	//***********************************************************************************

	[PunRPC]
	public void Run(){
		//Customer.GetComponentInChildren<TVScript> ().TurnOnTv ();
	}

	[PunRPC]
	public void Rumble(){
		Handheld.Vibrate ();
	}
}
