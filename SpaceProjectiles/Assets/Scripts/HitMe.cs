using UnityEngine;
using System.Collections;

public class HitMe : MonoBehaviour {

	private BattleLoad gameControl;

	// Use this for initialization
	void Start () {
		GameObject gameContObj = GameObject.FindWithTag ("GameControl");
		if (gameContObj != null) {
						gameControl = gameContObj.GetComponent<BattleLoad> ();
				}
	
	}
	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
		gameControl.setScore (5);
		}
	
}
