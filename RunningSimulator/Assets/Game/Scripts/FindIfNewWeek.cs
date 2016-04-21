using UnityEngine;
using System.Collections;

public class FindIfNewWeek : MonoBehaviour {

	private static System.DateTime startDate ;
	private static System.DateTime today ;
	private string[] myWeek = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
	private string[] myPrefs = {
		"SundayMiles",
		"MondayMiles",
		"TuesdayMiles",
		"WednesdayMiles",
		"ThursdayMiles",
		"FridayMiles",
		"SaturdayMiles"
	};

	void Start () {
		SetStartDate (); //do this first
		setPastEmpty(); // I think this is working
		setFutureEmpty (System.DateTime.Now.DayOfWeek.ToString());
		RefreshStartDate (); // do this last
	}

	void SetStartDate(){ //do this first
		startDate = System.Convert.ToDateTime( PlayerPrefs.GetString ("DateInitialized") );
	}

	void RefreshStartDate(){ //Do this last
			startDate = System.DateTime.Now;
			PlayerPrefs.SetString("DateInitialized", startDate.ToString());
	}

	public static double GetDaysPassed()
	{
		today = System.DateTime.Now ;
		System.TimeSpan elapsed = today.Subtract(startDate) ;
		double days = elapsed.TotalDays ;
		return days ;
	}

	public int numberDay(){
		
		if (System.DateTime.Now.DayOfWeek.ToString () == "Sunday") {
			return 0;
		} else if (System.DateTime.Now.DayOfWeek.ToString () == "Monday") {
			return 1;
		} else if (System.DateTime.Now.DayOfWeek.ToString () == "Tuesday") {
			return 2;
		} else if (System.DateTime.Now.DayOfWeek.ToString () == "Wednesday") {
			return 3;
		} else if (System.DateTime.Now.DayOfWeek.ToString () == "Thursday") {
			return 4;
		} else if (System.DateTime.Now.DayOfWeek.ToString () == "Friday") {
			return 5;
		} else {
			return 6;
		}
	}
		
	void setPastEmpty(){

		double countingDays = GetDaysPassed ();
		System.DateTime currentTime = System.DateTime.Now;

		if (GetDaysPassed () > 7) {
			setAllDaysEmpty ();
		}
		if ((System.DateTime.Now.AddDays (GetDaysPassed () * -1).DayOfWeek.ToString() == "Saturday" || GetDaysPassed () > 1) && System.DateTime.Now.DayOfWeek.ToString () == "Sunday") {
			setAllDaysEmpty ();
		} else if ((System.DateTime.Now.AddDays (GetDaysPassed () * -1).DayOfWeek.ToString() == "Saturday" || GetDaysPassed () > 2) && System.DateTime.Now.DayOfWeek.ToString () == "Monday") {
			setAllDaysEmpty ();
		} else if ((System.DateTime.Now.AddDays (GetDaysPassed () * -1).DayOfWeek.ToString() == "Saturday" || GetDaysPassed () > 3) && System.DateTime.Now.DayOfWeek.ToString () == "Tuesday") {
			setAllDaysEmpty ();
		} else if ((System.DateTime.Now.AddDays (GetDaysPassed () * -1).DayOfWeek.ToString() == "Saturday" || GetDaysPassed () > 4) && System.DateTime.Now.DayOfWeek.ToString () == "Wednesday") {
			setAllDaysEmpty ();
		} else if ((System.DateTime.Now.AddDays (GetDaysPassed () * -1).DayOfWeek.ToString() == "Saturday" || GetDaysPassed () > 5) && System.DateTime.Now.DayOfWeek.ToString () == "Thursday") {
			setAllDaysEmpty ();
		} else if ((System.DateTime.Now.AddDays (GetDaysPassed () * -1).DayOfWeek.ToString() == "Saturday" || GetDaysPassed () > 6) && System.DateTime.Now.DayOfWeek.ToString () == "Friday") {
			setAllDaysEmpty ();
		} else if ((System.DateTime.Now.AddDays (GetDaysPassed () * -1).DayOfWeek.ToString() == "Saturday" || GetDaysPassed () > 7) && System.DateTime.Now.DayOfWeek.ToString () == "Saturday") {
			setAllDaysEmpty ();
		}
	}

	public void setDayEmpty(string day){
		if (day == "Sunday") {
			PlayerPrefs.SetFloat ("SundayMiles", 0f);
		} else if (day == "Monday") {
			PlayerPrefs.SetFloat ("MondayMiles", 0f);
		} else if (day == "Tuesday") {
			PlayerPrefs.SetFloat ("TuesdayMiles", 0f);
		} else if (day == "Wednesday") {
			PlayerPrefs.SetFloat ("WednesdayMiles", 0f);
		} else if (day == "Thursday") {
			PlayerPrefs.SetFloat ("ThursdayMiles", 0f);
		} else if (day == "Friday") {
			PlayerPrefs.SetFloat ("FridayMiles", 0f);
		} else if (day == "Saturday") {
			PlayerPrefs.SetFloat ("SaturdayMiles", 0f);
		}
	}

	void setAllDaysEmpty(){
		PlayerPrefs.SetFloat ("SundayMiles", 0f);
		PlayerPrefs.SetFloat ("MondayMiles", 0f);
		PlayerPrefs.SetFloat ("TuesdayMiles", 0f);
		PlayerPrefs.SetFloat ("WednesdayMiles", 0f);
		PlayerPrefs.SetFloat ("ThursdayMiles", 0f);
		PlayerPrefs.SetFloat ("FridayMiles", 0f);
		PlayerPrefs.SetFloat ("SaturdayMiles", 0f);
	}
		
	void setFutureEmpty(string day){
		if (day == "Sunday") {
			PlayerPrefs.SetFloat ("MondayMiles", 0f);
			PlayerPrefs.SetFloat ("TuesdayMiles", 0f);
			PlayerPrefs.SetFloat ("WednesdayMiles", 0f);
			PlayerPrefs.SetFloat ("ThursdayMiles", 0f);
			PlayerPrefs.SetFloat ("FridayMiles", 0f);
			PlayerPrefs.SetFloat ("SaturdayMiles", 0f);
		} else if (day == "Monday") {
			PlayerPrefs.SetFloat ("TuesdayMiles", 0f);
			PlayerPrefs.SetFloat ("WednesdayMiles", 0f);
			PlayerPrefs.SetFloat ("ThursdayMiles", 0f);
			PlayerPrefs.SetFloat ("FridayMiles", 0f);
			PlayerPrefs.SetFloat ("SaturdayMiles", 0f);
		} else if(day == "Tuesday"){
			PlayerPrefs.SetFloat ("WednesdayMiles", 0f);
			PlayerPrefs.SetFloat ("ThursdayMiles", 0f);
			PlayerPrefs.SetFloat ("FridayMiles", 0f);
			PlayerPrefs.SetFloat ("SaturdayMiles", 0f);
		}else if(day == "Wednesday"){
			PlayerPrefs.SetFloat ("ThursdayMiles", 0f);
			PlayerPrefs.SetFloat ("FridayMiles", 0f);
			PlayerPrefs.SetFloat ("SaturdayMiles", 0f);
		}else if(day == "ThursdayMiles"){
			PlayerPrefs.SetFloat ("FridayMiles", 0f);
			PlayerPrefs.SetFloat ("SaturdayMiles", 0f);
		}else if(day == "Friday"){
			PlayerPrefs.SetFloat ("SaturdayMiles", 0f);
		}
	}
}
