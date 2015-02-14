using UnityEngine;
using System.Collections;

public class RotatingAsteroid : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (Vector3.right*Time.deltaTime*10);
		transform.Rotate (Vector3.up*Time.deltaTime*10);
	}
}
