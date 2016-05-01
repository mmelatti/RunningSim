using UnityEngine;
using System.Collections;

public class TitleWithTouch : MonoBehaviour {

	private bool canStartCoroutine = false;
	private bool canExit = true;

	void Start () {
		canStartCoroutine = false;
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.O)) {
			StartCoroutine (DoSwitchLevel ());

		}
		if (Input.touchCount >= 3 && canStartCoroutine) {
			canStartCoroutine = false;
			StartCoroutine (timer ());
		}
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
			StartCoroutine (DoSwitchLevel ());
		}
		canStartCoroutine = true;
	}

	IEnumerator DoSwitchLevel ()
	{
		PhotonNetwork.Disconnect ();
		while (PhotonNetwork.connected)
			yield return null;
		Application.LoadLevel("Title");
	}
}
