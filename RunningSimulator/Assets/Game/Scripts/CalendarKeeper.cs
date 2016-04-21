using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;

public class CalendarKeeper : MonoBehaviour {

	public GameObject Sunday;
	public GameObject Monday;
	public GameObject Tuesday;
	public GameObject Wednesday;
	public GameObject Thursday;
	public GameObject Friday;
	public GameObject Saturday;

	void Start () {
		
		Sunday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, PlayerPrefs.GetFloat("SundayMiles") * 10);
		Monday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, PlayerPrefs.GetFloat("MondayMiles") * 10);
		Tuesday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, PlayerPrefs.GetFloat("TuesdayMiles") * 10);
		Wednesday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, PlayerPrefs.GetFloat("WednesdayMiles") * 10);
		Thursday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, PlayerPrefs.GetFloat("ThursdayMiles") * 10);
		Friday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, PlayerPrefs.GetFloat("FridayMiles") * 10);
		Saturday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, PlayerPrefs.GetFloat("SaturdayMiles") * 10);

		ifZero ();
		ifHigh ();
	}

	void ifZero(){
		if (PlayerPrefs.GetFloat ("SundayMiles") < 0.5f) {
			Sunday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 5);
		}
		if (PlayerPrefs.GetFloat ("MondayMiles") < 0.5f) {
			Monday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 5);
		}
		if (PlayerPrefs.GetFloat ("TuesdayMiles") < 0.5f) {
			Tuesday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 5);
		}
		if (PlayerPrefs.GetFloat ("WednesdayMiles") < 0.5f) {
			Wednesday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 5);
		}
		if (PlayerPrefs.GetFloat ("ThursdayMiles") < 0.5f) {
			Thursday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 5);
		}
		if (PlayerPrefs.GetFloat ("FridayMiles") < 0.5f) {
			Friday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 5);
		}
		if (PlayerPrefs.GetFloat ("SaturdayMiles") < 0.5f) {
			Saturday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 5);
		}
	}

	void ifHigh(){
		if (PlayerPrefs.GetFloat ("SundayMiles") > 15f) {
			Sunday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 150);
		}
		if (PlayerPrefs.GetFloat ("MondayMiles") > 15f) {
			Monday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 150);
		}
		if (PlayerPrefs.GetFloat ("TuesdayMiles") > 15f) {
			Tuesday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 150);
		}
		if (PlayerPrefs.GetFloat ("WednesdayMiles") > 15f) {
			Wednesday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 150);
		}
		if (PlayerPrefs.GetFloat ("ThursdayMiles") > 15f) {
			Thursday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 150);
		}
		if (PlayerPrefs.GetFloat ("FridayMiles") > 15f) {
			Friday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 150);
		}
		if (PlayerPrefs.GetFloat ("SaturdayMiles") > 15f) {
			Saturday.GetComponent<RectTransform> ().sizeDelta = new Vector2 (36, 150);
		}
	}
		
}
