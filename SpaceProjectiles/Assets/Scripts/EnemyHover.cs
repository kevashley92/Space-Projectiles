using UnityEngine;
using System.Collections;

public class EnemyHover : MonoBehaviour {
	float step;
	void Start () {
		step = 1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		step += 0.1f;
		if (step > 99) {
			step = 1f;
		}
		transform.Translate (new Vector3 (0f, 0.01f*(Mathf.Sin (step))));
		
	}
}
