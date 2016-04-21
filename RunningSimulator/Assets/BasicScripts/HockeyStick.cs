using UnityEngine;
using System.Collections;

public class HockeyStick : MonoBehaviour {

	/* PlayerPref types:
	"points" (int)
	"Weapon" (int) 1 = HockeyStick, 2 = baseballBat,  
	

	*/


	public Animator animation;
	public AnimatorOverrideController controller;
	CharacterController characterController;
	bool oneHit = true;
	public BoxCollider hitBox;

	public GameObject zombieChar; //import zomibe character

	public GameObject combatHelm; //on zombie
	public GameObject combatHelm2; //on stand
	bool currentlySelectHelm = false;

	public GameObject regHat;
	public GameObject regHat2;
	bool currentlySelectHat = false;

	public GameObject pumpkinHat;
	public GameObject pumpkinHat2;
	bool currentlySelectPumpkin = false;

	public GameObject hockeyStick; //on player
	public GameObject hockeyStick2; // on stand
	bool currentlySelectHockey = false;

	public GameObject baseballBat;
	public GameObject baseballBat2;
	bool currentlySelectBat = false;




	AudioSource audio;

	void Start () {
		currentlySelectHockey = true;
		audio = GetComponent<AudioSource>();
	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.F) || Input.GetButton("Button 0") || Input.GetButton("Button 1") || Input.GetButton("Button 2") || Input.GetButton("Button 3")){
			if(oneHit){
				oneHit = false;
				StartCoroutine (startHit ());
			}
		}
	}

	public void punch(){
		if(oneHit){
			oneHit = false;
			StartCoroutine (startHit ());
		}
	}

	IEnumerator SwingBat() {
		animation.SetBool("swingBat",true);
		yield return new WaitForSeconds(.05f);
		animation.SetBool("swingBat",false);
		yield return new WaitForSeconds(.14f);
		animation.SetBool ("idle", true);
		yield return new WaitForSeconds (.05f);
		animation.SetBool ("idle", false);
		yield return 0;
	}

	IEnumerator SwingHockeyStick() {
		animation.SetBool("swingHockey",true);
		yield return new WaitForSeconds(.05f);
		animation.SetBool("swingHockey",false);
		yield return new WaitForSeconds(.14f);
		animation.SetBool ("idle", true);
		yield return new WaitForSeconds (.05f);
		animation.SetBool ("idle", false);
		yield return 0;
	}

	IEnumerator startHit() {
		hitBox.center = new Vector3 (0, 0, 1.5f);
		if (currentlySelectBat) {
			//animation.Play ("BaseBallBat");
			StartCoroutine (SwingBat ());
		} else if (currentlySelectHockey) {
			//animation.Play ("mainPlayer");
			StartCoroutine(SwingHockeyStick());
		}
		yield return new WaitForSeconds(.2f);
		hitBox.center = new Vector3 (0, 0, 0f);

		yield return new WaitForSeconds(.8f);
		oneHit = true;
		yield return 0;
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Zombie")
		{
			col.gameObject.GetComponent<zombie> ().hitZom = true;
		}

		if (col.gameObject.name == "SelectHelm") 
		{
			if (currentlySelectHelm) { //hat is on zombie, and we take it off
				audio.Play();
				currentlySelectHelm = false;
				closeAllHatsOnZombie ();
				combatHelm2.gameObject.transform.localScale = new Vector3 (0.03f, 0.03f, 0.03f);

			} else if( PlayerPrefs.GetInt("points") >= 10){ //hat is off zombie and we put it on.
				PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") - 10);
				audio.Play();
				currentlySelectHelm = true;
				currentlySelectHat = false;
				currentlySelectPumpkin = false;
				closeAllHatsOnZombie ();
				openAllSelectHats ();
				combatHelm.gameObject.transform.localScale = new Vector3 (0.015f, 0.015f, 0.015f);
				combatHelm2.gameObject.transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
			}
		}//end select Helm

		if (col.gameObject.name == "SelectPumpkin") 
		{
			if (currentlySelectPumpkin) { //hat is on zombie, and we take it off
				audio.Play();
				currentlySelectPumpkin = false;
				closeAllHatsOnZombie ();
				pumpkinHat2.gameObject.transform.localScale = new Vector3 (0.08f, 0.115f, 0.08f);

			} else if( PlayerPrefs.GetInt("points") >= 10){ //hat is off zombie and we put it on.
				PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") - 10);
				audio.Play();
				currentlySelectHelm = false;
				currentlySelectHat = false;
				currentlySelectPumpkin = true;
				closeAllHatsOnZombie ();
				openAllSelectHats ();
				pumpkinHat.gameObject.transform.localScale = new Vector3 (0.08f, 0.115f, 0.08f);
				pumpkinHat2.gameObject.transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
			}
		}//end select pumpkin

		if (col.gameObject.name == "SelectHat") 
		{
			if (currentlySelectHat) { //hat is on zombie, and we take it off
				audio.Play();
				currentlySelectHat = false;
				closeAllHatsOnZombie ();
				regHat2.gameObject.transform.localScale = new Vector3 (0.001f, 0.001f, 0.001f);

			} else if( PlayerPrefs.GetInt("points") >= 10){ //hat is off zombie and we put it on.
				PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") - 10);
				audio.Play();
				currentlySelectHelm = false;
				currentlySelectHat = true;
				currentlySelectPumpkin = false;
				closeAllHatsOnZombie ();
				openAllSelectHats ();
				regHat.gameObject.transform.localScale = new Vector3 (0.001f, 0.001f, 0.001f);
				regHat2.gameObject.transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
			}
		}//end select Hat

		if (col.gameObject.name == "SelectHockeyStick") 
		{
			if (currentlySelectHockey) { //hat is on zombie, and we take it off
				//Do nothing

			} else if( PlayerPrefs.GetInt("points") >= 10){ //hat is off zombie and we put it on.
				PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") - 10);
				audio.Play();

				currentlySelectHockey = true;
				currentlySelectBat = false;

				returnWeaponsToStand ();
				removePlayerWeapons ();

				hockeyStick.gameObject.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
				hockeyStick2.gameObject.transform.localScale = new Vector3 (0f, 0f, 0f);
			}
		}//end select HockeyStick

		if (col.gameObject.name == "SelectBaseballBat") 
		{
			if (currentlySelectBat) { //hat is on zombie, and we take it off
				//Do nothing

			} else if( PlayerPrefs.GetInt("points") >= 10){ //hat is off zombie and we put it on.
				PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") - 10);
				audio.Play();

				currentlySelectHockey = false;
				currentlySelectBat = true;

				returnWeaponsToStand ();
				removePlayerWeapons ();

				baseballBat.gameObject.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
				baseballBat2.gameObject.transform.localScale = new Vector3 (0f, 0f, 0f);
			}
		}//end select baseba;;Bat



	}

	void removePlayerWeapons(){
		hockeyStick.gameObject.transform.localScale = new Vector3 (0, 0, 0);
		baseballBat.gameObject.transform.localScale = new Vector3 (0, 0, 0);
	}

	void returnWeaponsToStand(){
		hockeyStick2.gameObject.transform.localScale = new Vector3 (.2f, .2f, .2f);
		baseballBat2.gameObject.transform.localScale = new Vector3 (.2f, .2f, .2f);
	}

	void openAllSelectHats(){
		pumpkinHat2.gameObject.transform.localScale = new Vector3 (0.08f, 0.115f, 0.08f);
		regHat2.gameObject.transform.localScale = new Vector3 (0.001f, 0.001f, 0.001f);
		combatHelm2.gameObject.transform.localScale = new Vector3 (0.03f, 0.03f, 0.03f);
	}

	void closeAllHatsOnZombie(){
		combatHelm.gameObject.transform.localScale = new Vector3 (0, 0, 0);
		regHat.gameObject.transform.localScale = new Vector3 (0, 0, 0);
		pumpkinHat.gameObject.transform.localScale = new Vector3 (0, 0, 0);
	}

	/*
	void OnCollisionEnter (Collision col)
	{
		Collider myCollider = col.contacts[0].thisCollider;

		if(col.gameObject.name == "Zombie" && myCollider == hitBox)
		{
			Debug.Log ("Collision Detect");
			//Destroy(col.gameObject);
		}
	}
	*/
}
