using UnityEngine;
using System.Collections;

public class TitleWithTouch : MonoBehaviour {

	private bool canStartCoroutine = true;
	private bool canExit = true;
	private PhotonView myPhotonView; 

	void OnJoinedRoom()
	{
		myPhotonView =this.GetComponent<PhotonView>();
	}

	void Start () {
		canStartCoroutine = true;
	}
	
	void Update () {
		if (Input.touchCount == 1) {
			this.myPhotonView.RPC("Test", PhotonTargets.All);
		}

		if (Input.GetKeyDown (KeyCode.O)) {
			callExit ();
			StartCoroutine (DoSwitchLevel ());
		}
		if (Input.touchCount >= 3 && canStartCoroutine) {
			canStartCoroutine = false;
			StartCoroutine (timer ());
		}
	}

	public void callExit(){
		this.myPhotonView.RPC("Exit", PhotonTargets.All);
	}

	IEnumerator timer(){
		canExit = true;
		for (int i = 0; i < 500; i++) {
			yield return new WaitForSeconds(.01f);
			if(Input.touchCount < 3){
				canExit = false;
				break;
			}
		}
		if (canExit) {
			callExit ();
			StartCoroutine (DoSwitchLevel ());
		}
		canStartCoroutine = true;
	}

	IEnumerator DoSwitchLevel ()
	{
		yield return new WaitForSeconds(3f);
		PhotonNetwork.Disconnect ();
		while (PhotonNetwork.connected)
			yield return null;
		Application.LoadLevel("Title");
	}

	[PunRPC]
	public void Exit(){
		StartCoroutine (DoSwitchLevel ());
	}

	[PunRPC]
	public void Test(){
		Debug.Log ("RPC Works");
	}
}
