using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public Rigidbody myRigidBody;
	public GameObject eye;
	public int dayOfWeek;
	private AudioSource footstep;

	void Start () {
		AudioSource[] audios = GetComponents<AudioSource>();
		footstep = audios[0];

		dayOfWeek = getIntDayOfWeek ();
	}
	
	void Update () {
		if (PlayerPrefs.GetString ("Camera") == "cardboard") {
			if (Input.GetKeyDown (KeyCode.B)) {
				Run ();
				addToDayOfWeek (dayOfWeek);
			}
		}
	}

	public void Run(){
		if (PlayerPrefs.GetString ("Camera") == "cardboard") {
			footstep.Play ();
			StartCoroutine (RunCoroutine ());
		}
		//myRigidBody.velocity = eye.transform.forward * 2f;
	}

	IEnumerator RunCoroutine() {
		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds (.001f);
			myRigidBody.velocity = eye.transform.forward * 2f;
		}
	}

	public int getIntDayOfWeek(){
		if (System.DateTime.Now.DayOfWeek.ToString() == "Sunday") {
			return 0;
		} else if (System.DateTime.Now.DayOfWeek.ToString() == "Monday") {
			return 1;
		} else if (System.DateTime.Now.DayOfWeek.ToString() == "Tuesday") {
			return 2;
		} else if (System.DateTime.Now.DayOfWeek.ToString() == "Wednesday") {
			return 3;
		} else if (System.DateTime.Now.DayOfWeek.ToString() == "Thursday") {
			return 4;
		} else if (System.DateTime.Now.DayOfWeek.ToString() == "Friday") {
			return 5;
		} else {
			return 6;
		}
	}

	void addToDayOfWeek(int day){
		if (day == 0) {
			PlayerPrefs.SetFloat ("SundayMiles", PlayerPrefs.GetFloat ("SundayMiles") + .1f);
		} else if (day == 1) {
			PlayerPrefs.SetFloat ("MondayMiles", PlayerPrefs.GetFloat ("MondayMiles") + .1f);
		} else if (day == 2) {
			PlayerPrefs.SetFloat ("TuesdayMiles", PlayerPrefs.GetFloat ("TuesdayMiles") + .1f);
		} else if (day == 3) {
			PlayerPrefs.SetFloat ("WednesdayMiles", PlayerPrefs.GetFloat ("WednesdayMiles") + .1f);
		} else if (day == 4) {
			PlayerPrefs.SetFloat ("ThursdayMiles", PlayerPrefs.GetFloat ("ThursdayMiles") + .1f);
		} else if (day == 5) {
			PlayerPrefs.SetFloat ("FridayMiles", PlayerPrefs.GetFloat ("FridayMiles") + .1f);
		} else if (day == 6) {
			PlayerPrefs.SetFloat ("SaturdayMiles", PlayerPrefs.GetFloat ("SaturdayMiles") + .1f);
		}
	}
}