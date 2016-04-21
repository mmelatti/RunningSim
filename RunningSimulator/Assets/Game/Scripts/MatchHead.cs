using UnityEngine;
using System.Collections;

public class MatchHead : MonoBehaviour {

	public GameObject head;
	public GameObject playerhead;

	public void Start(){
		if (PlayerPrefs.GetString ("Camera") == "mainCamera") {
			head.GetComponent<CardboardHead> ().trackRotation = false;
			head.GetComponent<CardboardHead> ().trackPosition = false;
		}
	}

	void Update () {
		if (PlayerPrefs.GetString ("Camera") == "mainCamera") {
			//this.gameObject.transform = head.gameObject.transform;
			this.gameObject.transform.position = playerhead.gameObject.transform.position;
			//this.gameObject.transform.rotation = head.gameObject.transform.rotation;
		}
	}
}
