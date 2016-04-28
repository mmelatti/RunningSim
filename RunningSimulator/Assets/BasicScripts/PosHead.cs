using UnityEngine;
using System.Collections;

public class PosHead : MonoBehaviour {

	public GameObject Head;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetString ("Camera") == "cardboard") {
			this.gameObject.transform.position = Head.transform.position;
		} else {
			//this.gameObject.transform.position = Head.transform.position; //testing
			//do nothing
		}
	}
}
