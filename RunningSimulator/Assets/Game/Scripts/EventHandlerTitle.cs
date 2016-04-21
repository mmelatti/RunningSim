using UnityEngine;
using System.Collections;

public class EventHandlerTitle : MonoBehaviour {

	void Start () {

	}
	
	void Update () {
	
	}

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


}
