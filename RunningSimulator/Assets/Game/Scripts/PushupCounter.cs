using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PushupCounter : MonoBehaviour {

	public Text myText;
	private bool down = false;
	public GameObject head;

	void Start () {
		down = false;
		PlayerPrefs.SetInt ("Pushups", 0);
	}
	
	void Update () {
		myText.text = PlayerPrefs.GetInt ("Pushups").ToString();

		if (head.gameObject.transform.position.y < .027f) {
			down = true;
		}
		if (head.gameObject.transform.position.y > .15f && down) {
			down = false;
			PlayerPrefs.SetInt ("Pushups", PlayerPrefs.GetInt ("Pushups") + 1);
			Debug.Log (PlayerPrefs.GetInt ("Pushups"));
		}
	}
}
