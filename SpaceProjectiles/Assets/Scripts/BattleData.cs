using UnityEngine;
using System.Collections;

public class BattleData :MonoBehaviour{

	public  ProblemGenerator problem;
	public  int score = 0;
	public  bool used = false;
	public  Controller cont;
	public float answer;

	void Awake(){
		DontDestroyOnLoad (this);
		}
	public int getScore(){
		return score;
		}
}
