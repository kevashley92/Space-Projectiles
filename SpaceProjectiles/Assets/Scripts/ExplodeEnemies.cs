using UnityEngine;
using System.Collections;

public class ExplodeEnemies : MonoBehaviour {

	public GameObject explosion;
	public int numExplosions = 0;
	public int explosionRate = 0;

	// Use this for initialization
	void Update () {
		explosionRate++;
		int explosionSelectX = Mathf.RoundToInt (Random.Range (-5, 5));
		int explosionSelectY = Mathf.RoundToInt (Random.Range (-5, 5));
		if (explosionRate == 15 && numExplosions <= 5) {
			numExplosions++;
			Instantiate (explosion, new Vector3(transform.position.x + explosionSelectX, transform.position.y + explosionSelectY), transform.rotation);
			explosionRate = 0;
		}
	}
}
