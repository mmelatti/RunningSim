using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

	public float speed = 2f;

	void Update () {
		this.gameObject.transform.Rotate (Vector3.up, speed * Time.fixedDeltaTime);
	}
}
