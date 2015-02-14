using UnityEngine;
using System.Collections;

public class BattleLoad : MonoBehaviour {

	public const float X_SCALAR = .0042f;
	public const float Y_SCALAR = .2f;

	public ProblemGenerator problem;
	//private float time = 0f;
	public GameObject PirateShip;
	public GameObject HeroShip;
	public float heroScale;
	public float pirateScale;
	public float vel;
	public float distance;
	public GameObject shot;
	public Transform shotspawn;
	private float firerate;
	private float nextfire;
	private float answer;
	private int score;
	private float timer;
	private int questionType;
	private GameObject pirateMove;

	BattleData data;

	// Use this for initialization
	void Start () {
		//problem = new ProblemGenerator ();
		//Get the transfer data
		GameObject dataHolder = GameObject.FindWithTag ("DataManag");
		data = dataHolder.GetComponent<BattleData>();
		problem = data.cont.getProb ();
		score = data.score;
		Question questionData = data.cont.getQuesData ();
		questionType = questionData.getQuestNum ();
		timer = Time.time + 60f;
		answer = data.answer;
		firerate = problem.getTime () + 1f;

		//Place the hero's ship
		Vector3 startPosition = new Vector3 (0.0f, problem.getInitHeight () * Y_SCALAR, 0.0f);
		Quaternion spawnRoHero = Quaternion.identity;
		GameObject hero = Instantiate (HeroShip, startPosition, spawnRoHero) as GameObject;
		hero.transform.localScale = new Vector3 (heroScale, heroScale, heroScale);
		hero.transform.localEulerAngles = new Vector3 (4.4f, 117f, -22f);
		shotspawn = hero.transform;

		//Place the pirate ship
		Vector3 pirateStart;
		if (questionType == 1 || questionType == 2) {
			pirateStart = new Vector3 (problem.getDistance () * X_SCALAR, 0.0f, 0.0f);
		} else {
			pirateStart = new Vector3 (distance * X_SCALAR, 0f, 0f);
		}
		Quaternion spawnRo = Quaternion.identity;
		pirateMove = Instantiate (PirateShip, pirateStart, spawnRo) as GameObject;
		pirateMove.transform.localScale = new Vector3(pirateScale, pirateScale, pirateScale);
		pirateMove.transform.localEulerAngles = new Vector3(0.0f,-101f, 22f);
	}

	void OnGUI() {

		Color oldColor = GUI.color;
		GUI.color = Color.red;
		GUI.skin.box.fontSize = 40;
		if (questionType == 1 || questionType == 2) {
			GUI.Box (new Rect (0, 102, vel * (Screen.width / 1000), 50), vel + "");
		} else {
			GUI.Box (new Rect (0, 102, ((int)(distance * (Screen.width / 1000) * .4f)), 50), distance + "");
		}

		GUI.color = Color.white;
		int ansInt = (int)answer;
		if (questionType == 1 || questionType == 2) {
			GUI.Box (new Rect (0, 51, answer * (Screen.width / 1000), 50), ansInt + "");
		} else {
			GUI.Box (new Rect (0, 51, ((int)(answer * (Screen.width / 1000) * .4f)), 50), ansInt + "");
		}
		if (questionType == 1 || questionType == 2) {
			GUI.Box (new Rect (0, 0, answer * (Screen.width / 1000), 50), "Your Answer");
		} else {
			GUI.Box (new Rect (0, 0, ((int)(answer * (Screen.width / 1000) * .4f)), 50), "Your Answer");
		}
		GUI.skin.box.fontSize = 40;
		int timeLeft = (int)(-(Time.time - timer));
		GUI.Box (new Rect (Screen.width - 150, 0, 150, 50), timeLeft + "");

		GUI.color = Color.yellow;
		GUI.Box (new Rect (Screen.width - 400, Screen.height / 2 , 400, 50), "Current Score:");
		GUI.Box (new Rect (Screen.width - 400, Screen.height / 2 + 100, 400, 50), score + "");

		GUI.color = oldColor;
		if (timeLeft > 50) {
			GUI.skin.box.fontSize = 18;
			GUI.Box (new Rect (Screen.width / 3, Screen.height / 3, 500, 25), "Press W to increase value, S to decrease, and space to fire");
		}
	}
	// Update is called once per frame
	void Update () {
		//answer = problem.getXVel ();
		if (Input.GetKey ("w")){
			if (questionType == 1 || questionType == 2) {
				if (vel < .5f * answer) {
					vel = vel + 10f;
				} else {
					vel = vel + 1f;
				}
			} else {
				if (distance < .5f * answer){
					distance = distance + 10f;
				} else {
					distance = distance + 1f;
				}
			}
		}

		if (Input.GetKey("s")){
		    if (questionType == 3 || questionType == 4){
				if (distance < .5f * answer){
					distance = distance - 10f;
				} else {
					distance = distance - 1f;
				}
			} else {
				if (vel < .5f * answer){
					vel = vel - 10f;
				} else {
					vel = vel - 1f;
				}
			}
		}

		if (Input.GetKey ("space") && Time.time > nextfire) {
			nextfire = Time.time + firerate;
			GameObject newshot = Instantiate(shot, shotspawn.position, shotspawn.rotation) as GameObject;
			newshot.transform.localScale = new Vector3(.3f, .3f, .3f);
			Shot script = newshot.GetComponent<Shot>();
			script.acc = problem.getAccY();
			script.initHeight = problem.getInitHeight();
			if (questionType == 1 || questionType == 2){
				script.velocity = vel; //problem.getXVel();
			} else {
				script.velocity = problem.getXVel();
			}
			vel = 0f;

			if (questionType == 3 || questionType == 4) {
				pirateMove.rigidbody.position = new Vector3 (distance * X_SCALAR, 0f, 0f);
			}
			distance = 0f;

		}
		if (Time.time > timer) {
			data.score = score;
			Application.LoadLevel ("MainGame"); // go to new level
		}
	}

//	void FixedUpdate() {
//		if (questionType == 3 || questionType == 4) {
//			pirateMove.rigidbody.position = new Vector3 (distance * X_SCALAR, 0f, 0f);
//		}
//	}
	
	private float determineX(float time) {
		return time * problem.getXVel() * X_SCALAR;
	}
	private float determineY(float time) {
		return (problem.getInitHeight() + (Mathf.Pow (time, 2f) * problem.getAccY() / 2)) * Y_SCALAR;
	}
	public ProblemGenerator getProblem(){
				return problem;
		}
	public void setScore(int Val){
		score = score + Val;
		}
	public int getScore(){
		return score;
		}
}