using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pushupstat : MonoBehaviour {

	public Text myText;

	void Start () {
		myText.text = "Pushups: " + PlayerPrefs.GetInt ("Pushups"); 
	}
}
