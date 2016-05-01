using UnityEngine;
using System.Collections;

public class EventHandlerTitle : MonoBehaviour {
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			PlayerPrefs.SetString ("Camera", "cardboard");
			Application.LoadLevel ("HeadSet");
		} else if (Input.GetKeyDown (KeyCode.W)) {
			Application.LoadLevel ("TrackingDevice");
		} else if (Input.GetKeyDown (KeyCode.E)) {
			PlayerPrefs.SetString ("Camera", "mainCamera");
			Application.LoadLevel ("HeadSet");
		} else if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ("Stats");
		} else if (Input.GetKeyDown (KeyCode.T)) {
			PlayerPrefs.SetString ("Camera", "cardboard");
			Application.LoadLevel ("Pushups");
		} else if (Input.GetKeyDown (KeyCode.Y)) {
			PlayerPrefs.SetString ("Camera", "mainCamera");
			Application.LoadLevel ("Pushups");
		}
	} //end update

	public void ButtonStartHeadSet(){
		PlayerPrefs.SetString ("Camera", "cardboard");
		Application.LoadLevel ("HeadSet");
	}

	public void ButtonStartSpectator(){
		PlayerPrefs.SetString ("Camera", "mainCamera");
		Application.LoadLevel ("HeadSet");
	}

	public void ButtonStartTrackingDevice(){
		Application.LoadLevel ("TrackingDevice");
	}

	public void ButtonStartStat(){
		Application.LoadLevel ("Stats");
	}

	public void ButtonBackToTitle(){
		Application.LoadLevel ("Title");
	}

	public void ButtonToPushups(){
		PlayerPrefs.SetString ("Camera", "cardboard");
		Application.LoadLevel ("Pushups");
	}

	public void ButtonToPushupsSpectator(){
		PlayerPrefs.SetString ("Camera", "mainCamera");
		Application.LoadLevel ("Pushups");
	}
}