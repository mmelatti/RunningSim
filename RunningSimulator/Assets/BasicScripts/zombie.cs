using UnityEngine;
using System.Collections;

public class zombie : MonoBehaviour {

	public bool showpoints;

	CharacterController characterController;
	bool UseGravity = true;
	float Gravity = 9.8f;

	public GameObject player; // this is the target

	public Animator animation;
	public AnimatorOverrideController controller;


	//head stuff
	public GameObject childHead;
	public bool hitZom = false;
	bool oneHead = true;
	AudioSource audio;

	void Awake(){
		//characterController = GetComponent<CharacterController>();
	}

	void Start () {
		audio = GetComponent<AudioSource>();
	}

	IEnumerator startWalk03() {
		//yield return new WaitForSeconds(5);
		//animation.Play("walk01");
		animation.SetBool("walk03",true);
		yield return new WaitForSeconds(.01f);
		animation.SetBool("walk03",false);
		yield return 0;
	}

	IEnumerator startIdle01() {
		//yield return new WaitForSeconds(5);
		//animation.Play("walk01");
		animation.SetBool("idle01",true);
		yield return new WaitForSeconds(.01f);
		animation.SetBool("idle01",false);
		yield return 0;
	}

	void Update () {

		if (hitZom) {
			if (oneHead) {
				audio.Play();
				oneHead = false;
				StartCoroutine (hitHead ());
			}
		} else {
			rotatehead ();
		}

		rotateZombie ();

		//get position of player and set y position to .43 which is ground level
		Vector3 positionPlayer = player.transform.position;
		positionPlayer.y = -.50f;

		//calculate the distance between zombie and player
		float distance = Vector3.Distance(player.transform.position, transform.position);

		//based on distance move zombie toward player.
		if (distance > 4) {
			StartCoroutine (startWalk03 ());
			//animation.StopPlayback("idol01");
			//animation.Play("walk03");
			this.transform.position = Vector3.MoveTowards (this.transform.position, positionPlayer, 0.5f * Time.deltaTime);
		} else {
			StartCoroutine(startIdle01());
			//animation.StopPlayback("walk03");
			//animation.Play("idol01");
		}
		//if (!characterController.isGrounded && UseGravity) {
		//	characterController.SimpleMove (gameObject.transform.up * Gravity * Time.deltaTime);
		//}
	}

	void rotatehead(){
		childHead.transform.LookAt (player.transform);
		childHead.transform.Rotate (0, 0, -90);
	}

	void rotateZombie(){
		//get Direction from zombie to player
		Vector3 direction = (player.transform.position - transform.position).normalized;

		direction.y = 0; //look rotation of the zombie is the same

		//get rotation direction from zombie to player
		Quaternion lookRotation = Quaternion.LookRotation(direction);

		//rotate the zombie toward the player
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2);
	}

	IEnumerator hitHead() {
		Vector3 headPos = childHead.transform.position;
		PlayerPrefs.SetInt ("points", PlayerPrefs.GetInt("points") + 1);
		if(showpoints){
			Debug.Log("Player Points: " + PlayerPrefs.GetInt("points"));
		}
		for (int i = 0; i < 10; i++) {
			
			childHead.transform.Rotate (0, -60, -90);
			yield return new WaitForSeconds (.0001f);
		}
		//childHead.transform.position = new Vector3(0,0,0);
		hitZom = false;
		yield return new WaitForSeconds (.1f);
		oneHead = true;
		yield return 0;
	}


	/*
	void hitHead(){

		//childHead.transform.position = new Vector3 (childHead.transform.position.x, childHead.transform.position.y - .000000000001f, childHead.transform.position.z);
		childHead.transform.Translate(Vector3.down * .01f * Time.deltaTime);

		if(childHead.transform.position.y < headPos.y){
			childHead.transform.position = headPos;
			hitZom = false;
			doHeadPopOnce = true;
		}
	}
	*/
		
}
