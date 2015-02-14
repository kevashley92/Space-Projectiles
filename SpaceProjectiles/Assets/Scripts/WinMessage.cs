using UnityEngine;
using System.Collections;

public class WinMessage : MonoBehaviour {

	int maxMove = 0;
	float rate = 5;
	// Update is called once per frame
	void Update () {
		if (maxMove <= 100) {
			transform.position += transform.TransformDirection (Vector3.back)/rate;
			maxMove++;
		}
	}
}
