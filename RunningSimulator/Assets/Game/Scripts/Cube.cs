using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public GameObject cubeBlue1;
	public GameObject cubeBlue2;
	public GameObject cubeBlue3;
	public GameObject cubeBlue4;
	public GameObject cubeBlue5;
	public GameObject cubeBlue6;
	public GameObject cubeBlue7;
	public GameObject cubeBlue8;
	AudioSource audio;

	public int cubeNumber = 0;

	void Start(){
		audio = GetComponent<AudioSource>();
	}

	public void spawnNewCube(){

		int randomInt = 0;
		bool lookForNum = true;

		//Get random int
		while (lookForNum) {
			randomInt = Random.Range (1, 9);
			if (randomInt != cubeNumber) {
				lookForNum = false;
			}
		}

		audio.Play();
		SetActiveCube (randomInt);
		CurrentCubeDeactiveate ();
	}

	public void CurrentCubeDeactiveate(){
		if (cubeNumber == 1) {
			cubeBlue1.SetActive (false);
		} else if (cubeNumber == 2) {
			cubeBlue2.SetActive (false);
		} else if (cubeNumber == 3) {
			cubeBlue3.SetActive (false);
		} else if (cubeNumber == 4) {
			cubeBlue4.SetActive (false);
		} else if (cubeNumber == 5) {
			cubeBlue5.SetActive (false);
		} else if (cubeNumber == 6) {
			cubeBlue6.SetActive (false);
		} else if (cubeNumber == 7) {
			cubeBlue7.SetActive (false);
		} else if (cubeNumber == 8) {
			cubeBlue8.SetActive (false);
		}
	}

	public void SetActiveCube(int num){
		if (num == 1) {
			cubeBlue1.SetActive (true);
		} else if (num == 2) {
			cubeBlue2.SetActive (true);
		} else if (num == 3) {
			cubeBlue3.SetActive (true);
		} else if (num == 4) {
			cubeBlue4.SetActive (true);
		} else if (num == 5) {
			cubeBlue5.SetActive (true);
		} else if (num == 6) {
			cubeBlue6.SetActive (true);
		} else if (num == 7) {
			cubeBlue7.SetActive (true);
		} else if (num == 8) {
			cubeBlue8.SetActive (true);
		}
	}
		
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "RigidBodyFPSController") {
			spawnNewCube ();
		}
	}
}
