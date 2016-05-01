using UnityEngine;
using System.Collections;

public class Gametrak : MonoBehaviour {
	//this example sets the orientation of the left and right positions of the gametrak controllers. 

	//192.168.43.57
	//192.168.43.255
	//27.0.0.1

	public string server = "chair_gametrak@192.168.43.57:3883";
	public Transform left;
	public Transform right;
	public int[] buttons = new int[1]; //if you have the button attached

	Vector3 leftPos;
	Vector3 rightPos;
	Quaternion temp;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		UnityVRPN.getTrackerInfo (server, 0, ref leftPos, ref temp);
		UnityVRPN.getTrackerInfo (server, 1, ref rightPos, ref temp);
		left.localPosition = leftPos;
		right.localPosition = rightPos;
		UnityVRPN.getButtonInfo (server, 1, buttons);

	}
}
