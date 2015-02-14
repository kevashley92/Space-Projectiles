using UnityEngine;
using System.Collections;

public class FlyForward : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.position += transform.TransformDirection (Vector3.forward);
	}
}
