using UnityEngine;
using System.Collections;

public class Answers{

	private string answerText;
	private bool correctAns;
	private int nextStage;

	public Answers(bool correct, string text, int next){
				answerText = text;
				correctAns = correct;
		nextStage = next;
		}
	public string getAnswerText(){
				return answerText;
		}
	public bool getIsCorrect(){
				return correctAns;
		}
	public int getNextStage(){
				return nextStage;
		}

}
