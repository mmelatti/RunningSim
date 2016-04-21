using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrintToScreen : MonoBehaviour {

	public Text myText;
	public GameObject carboard;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		myText.text = carboard.transform.rotation.y.ToString();
	}
}
