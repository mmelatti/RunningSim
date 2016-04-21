using UnityEngine;
using System.Collections;

public class GetRunTracking : MonoBehaviour {

	public GameObject Player;

	private PhotonView myPhotonView; //create this photonView Object

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
}
