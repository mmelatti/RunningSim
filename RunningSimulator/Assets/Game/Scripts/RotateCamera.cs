using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

	public float speed = 2f;

	void FixedUpdate () {
		this.gameObject.transform.Rotate (Vector3.up, speed * Time.fixedDeltaTime);
	}
}
