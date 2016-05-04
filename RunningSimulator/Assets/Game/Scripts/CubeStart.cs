using UnityEngine;
using System.Collections;

public class CubeStart : MonoBehaviour {

	public GameObject cubeBlue1;
	public GameObject cubeBlue2;
	public GameObject cubeBlue3;
	public GameObject cubeBlue4;
	public GameObject cubeBlue5;
	public GameObject cubeBlue6;
	public GameObject cubeBlue7;
	public GameObject cubeBlue8;

	void Start () {
		int randomInt = Random.Range (1, 9);
		if (randomInt == 1) {
			cubeBlue1.SetActive (true);
		} else if (randomInt == 2) {
			cubeBlue2.SetActive (true);
		} else if (randomInt == 3) {
			cubeBlue3.SetActive (true);
		} else if (randomInt == 4) {
			cubeBlue4.SetActive (true);
		} else if (randomInt == 5) {
			cubeBlue5.SetActive (true);
		} else if (randomInt == 6) {
			cubeBlue6.SetActive (true);
		} else if (randomInt == 7) {
			cubeBlue7.SetActive (true);
		} else if (randomInt == 8) {
			cubeBlue8.SetActive (true);
		}
	}

}