using UnityEngine;
using System.Collections;

public class DeviceCapture : MonoBehaviour {


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
		if (Input.acceleration.x > 1.5 || Input.acceleration.y > 1.5  || Input.acceleration.z > 1.5 ) {
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
		Debug.Log("Punch");
	}
}
