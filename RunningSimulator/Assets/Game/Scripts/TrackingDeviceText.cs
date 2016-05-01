using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrackingDeviceText : MonoBehaviour {

	public Text myText;

	void Start () {
		StartCoroutine(Loading());
	}

	IEnumerator Loading() {
		while (true) {
			yield return new WaitForSeconds(2f);
			myText.text = "Tracking Device";
			yield return new WaitForSeconds(2f);
			myText.text = "Tracking Device.";
			yield return new WaitForSeconds(2f);
			myText.text = "Tracking Device..";
			yield return new WaitForSeconds(2f);
			myText.text = "Tracking Device...";
		}
	}
}
