using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	public const float X_SCALAR = .0042f;
	public const float Y_SCALAR = .2f;
	private float time = 0f;
	public float velocity;
	public float initHeight;
	public float acc;

	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		float xVal = determineX (time);
		float yVal = determineY (time);
		Vector3 newPosition = new Vector3 (xVal, yVal, 0.0f);
		rigidbody.position = newPosition;

	}
	private float determineX(float time) {
		return time * velocity * X_SCALAR;
	}
	private float determineY(float time) {

		return (initHeight + (Mathf.Pow (time, 2f) * acc / 2)) * Y_SCALAR;
	}
}
