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
			Vector3 myTransform = playerhead.gameObject.transform.position;
			myTransform.y = myTransform.y + 1;


			this.gameObject.transform.position = myTransform;
			//this.gameObject.transform.rotation = head.gameObject.transform.rotation;
		}
	}
}
