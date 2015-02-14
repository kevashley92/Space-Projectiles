using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	public string var1 = "";
	public string var2 = "";
	public string var3 = "";
	public string var4 = "";
	public string var5 = "";
	public string question = "";
	public string task = "";
	public int taskType = 0;
	public Answers [] answers;
	public string [] hints;
	public int score = 0;
	public int nextStage = 0;
	public int hintIndex = -1;
	public string fillInVar = "";
	int totalRightChoices = 0;
	public Texture rpNeutral;
	public Texture rpHappy;
	public Texture rpDisappointed;
	public int startScore = 0;
	public int endScore = 0;


	Controller con;

	void Start () {
		GameObject dataHolder = GameObject.FindWithTag ("DataManag");
		BattleData data = dataHolder.GetComponent<BattleData>();
		if (data.used == false) {
			con = new Controller ();
			score = 0;
		} else {
			con = data.cont;
			score = data.score;
			con.returnToQuiz();
		}
		question = con.getQuestion ();
		answers = con.getAnswers ();
		task = con.getTask ();
		taskType = con.getTaskType ();
		hints = con.getHints ();
		guiTexture.texture = rpNeutral;
	}

	void OnGUI () {
		score = con.getScore ();
		startScore = score;
		question = con.getQuestion ();
		answers = con.getAnswers ();
		task = con.getTask ();
		taskType = con.getTaskType ();
		hints = con.getHints ();
		hintIndex = con.getHintIndex ();

		GUI.skin.box.fontSize = 24;
		GUI.Box (new Rect (10, 10, 100, Screen.height/10), "Score:\n" + score);

		GUI.skin.box.wordWrap = true;
		GUI.skin.box.fontSize = 18;
		GUI.skin.button.wordWrap = true;
		GUI.skin.button.fontSize = 14;
		GUI.skin.button.focused.textColor = Color.green;
		// Make a box for the main task/question
		GUI.Box(new Rect(Screen.width/4, Screen.height-(Screen.height-10), Screen.width/2, 100), task);

		// Make a background box
		GUI.Box(new Rect(Screen.width - 300, Screen.height-(Screen.height-10), 290, Screen.height-20), "");

		GUI.skin.box.fontSize = 22;
		// Make the box for the narrative
		GUI.Box(new Rect(Screen.width - 290, Screen.height-(Screen.height-20), 270, (Screen.height/4)), question);
		GUI.skin.box.fontSize = 14;

		/*GUI.skin.button.normal.textColor = Color.blue;
		// Make the Gather Intel button. If it is pressed, Application.GatherIntel will be executed
		if(GUI.Button(new Rect(Screen.width - 290, (Screen.height/2)-150, 270, 60), "GATHER INTEL")) {
			//Application.GatherIntel();
		}*/

		GUI.skin.button.normal.textColor = Color.yellow;
		// Make the Consult RoboPoly button. If it is pressed, Application.ConsultRoboPoly will be executed
		if(GUI.Button(new Rect(Screen.width - 290, (Screen.height/2)-80, 270, 60), "CONSULT ROBOPOLY")) {
			con.useHint (hintIndex+1);
			guiTexture.texture = rpHappy;
		}

		GUI.skin.button.normal.textColor = Color.white;

		GUI.skin.box.fontSize = 18;
		if (hintIndex >= 0 && hintIndex < con.getNumHints ()) {
			// Make a box for the hints
			GUI.Box(new Rect(Screen.width-(Screen.width-10), Screen.height-80, Screen.width/4, 70), hints[hintIndex]);
		} else if (hintIndex >= con.getNumHints ()) {
			// Make a box for the hints
			GUI.Box(new Rect(Screen.width-(Screen.width-10), Screen.height-80, Screen.width/4, 70), hints[con.getNumHints ()-1]);
		}
		GUI.skin.box.fontSize = 14;

		// MULTIPLE CHOICE
		if (con.getStageType () == 0) {
			if(con.getNumAnswers () == 4) {
				// Make the answer 1 button. If it is pressed, Application.answer(1) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) - 10, 245, 70), answers[0].getAnswerText ())) {
					con.answerQuestion (0);
				}
				// Make the answer 2 button. If it is pressed, Application.answer(2) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 70, 245, 70), answers[1].getAnswerText ())) {
					con.answerQuestion (1);
				}
				// Make the answer 3 button. If it is pressed, Application.answer(3) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 150, 245, 70), answers[2].getAnswerText ())) {
					con.answerQuestion (2);
				}
				// Make the answer 4 button. If it is pressed, Application.answer(4) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 230, 245, 70), answers[3].getAnswerText ())) {
					con.answerQuestion (3);
				}
			} else if (con.getNumAnswers () == 3) {
				// Make the answer 1 button. If it is pressed, Application.answer(1) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) - 10, 245, 70), answers[0].getAnswerText ())) {
					con.answerQuestion (0);
				}
				// Make the answer 2 button. If it is pressed, Application.answer(2) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 70, 245, 70), answers[1].getAnswerText ())) {
					con.answerQuestion (1);
				}
				// Make the answer 3 button. If it is pressed, Application.answer(3) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 150, 245, 70), answers[2].getAnswerText ())) {
					con.answerQuestion (2);
				}
			} else if (con.getNumAnswers () == 2) {
				// Make the answer 1 button. If it is pressed, Application.answer(1) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) - 10, 245, 70), answers[0].getAnswerText ())) {
					con.answerQuestion (0);
				}
				// Make the answer 2 button. If it is pressed, Application.answer(2) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 70, 245, 70), answers[1].getAnswerText ())) {
					con.answerQuestion (1);
				}
			}
		// FILL IN THE BLANK
		} else if (con.getStageType () == 1) {
			GUI.skin.box.fontSize = 22;
			GUI.Box(new Rect(Screen.width - 290, (Screen.height/2), 270, 90), "Answer (2 decimals max):");
			GUI.skin.box.fontSize = 14;
			GUI.skin.textField.fontSize = 22;
			// Make the text field for the first variable
			var1 = GUI.TextField (new Rect (Screen.width - 250, (Screen.height / 2) + 40, 190, 35), var1, 25);
			// Make the Fire button. If it is pressed, Application.SubmitSolution will be executed
			GUI.skin.button.fontSize = 22;
			if (GUI.Button (new Rect (Screen.width - 290, (Screen.height / 2) + 110, 270, 100), "ENTER PARAMETER")) {
				con.fillIn (var1);
				var1 = "";
			}
			GUI.skin.button.fontSize = 14;
		// CHOICE
		} else if (con.getStageType () == 2) {
			if(con.getNumAnswers () == 4) {
				// Make the answer 1 button. If it is pressed, Application.answer(1) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) - 10, 245, 70), answers[0].getAnswerText ())) {
					con.choose (0);
				}
				// Make the answer 2 button. If it is pressed, Application.answer(2) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 70, 245, 70), answers[1].getAnswerText ())) {
					con.choose (1);
				}
				// Make the answer 3 button. If it is pressed, Application.answer(3) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 150, 245, 70), answers[2].getAnswerText ())) {
					con.choose (2);
				}
				// Make the answer 4 button. If it is pressed, Application.answer(4) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 230, 245, 70), answers[3].getAnswerText ())) {
					con.choose (3);
				}
			} else if (con.getNumAnswers () == 3) {
				// Make the answer 1 button. If it is pressed, Application.answer(1) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) - 10, 245, 70), answers[0].getAnswerText ())) {
					con.choose (0);
				}
				// Make the answer 2 button. If it is pressed, Application.answer(2) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 70, 245, 70), answers[1].getAnswerText ())) {
					con.choose (1);
				}
				// Make the answer 3 button. If it is pressed, Application.answer(3) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 150, 245, 70), answers[2].getAnswerText ())) {
					con.choose (2);
				}
			} else if (con.getNumAnswers () == 2) {
				// Make the answer 1 button. If it is pressed, Application.answer(1) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) - 10, 245, 70), answers[0].getAnswerText ())) {
					con.choose (0);
				}
				// Make the answer 2 button. If it is pressed, Application.answer(2) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 70, 245, 70), answers[1].getAnswerText ())) {
					con.choose (1);
				}
			}
		// SELECT MULTIPLE
		} else if (con.getStageType () == 3) {
			GUI.skin.button.fontSize = 11;
			if(con.getNumAnswers () == 10) {
				// Make the answer 1 button. If it is pressed, Application.answer(1) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) - 5, 245, 25), answers[0].getAnswerText ())) {
					con.selectMultiple (0);
					GUI.color = Color.white;
					GUI.Box (new Rect (Screen.width - 282, (Screen.height / 2) - 7, 247, 27), answers[0].getAnswerText ());
				}
				// Make the answer 2 button. If it is pressed, Application.answer(2) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 25, 245, 25), answers[1].getAnswerText ())) {
					con.selectMultiple (1);
				}
				// Make the answer 3 button. If it is pressed, Application.answer(3) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 55, 245, 25), answers[2].getAnswerText ())) {
					con.selectMultiple (2);
				}
				// Make the answer 4 button. If it is pressed, Application.answer(4) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 85, 245, 25), answers[3].getAnswerText ())) {
					con.selectMultiple (3);
				}
				// Make the answer 5 button. If it is pressed, Application.answer(4) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 115, 245, 25), answers[4].getAnswerText ())) {
					con.selectMultiple (4);
				}
				// Make the answer 6 button. If it is pressed, Application.answer(4) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 145, 245, 25), answers[5].getAnswerText ())) {
					con.selectMultiple (5);
				}
				// Make the answer 7 button. If it is pressed, Application.answer(4) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 175, 245, 25), answers[6].getAnswerText ())) {
					con.selectMultiple (6);
				}
				// Make the answer 8 button. If it is pressed, Application.answer(4) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 205, 245, 25), answers[7].getAnswerText ())) {
					con.selectMultiple (7);
				}
				// Make the answer 9 button. If it is pressed, Application.answer(4) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 235, 245, 25), answers[8].getAnswerText ())) {
					con.selectMultiple (8);
				}
				// Make the answer 10 button. If it is pressed, Application.answer(4) will be executed
				if (GUI.Button (new Rect (Screen.width - 280, (Screen.height / 2) + 265, 245, 25), answers[9].getAnswerText ())) {
					con.selectMultiple (9);
				}
				// Make the Fire button. If it is pressed, Application.SubmitSolution will be executed
				if (GUI.Button (new Rect (Screen.width - 290, (Screen.height / 2) + 310, 270, 30), "FIRE!!!")) {
					//Application.SubmitSolution();
				}

			}
		// SKIP
		} else if (con.getStageType () == 4) {
			con.skipQuestion (0);
		} else {
			// Make the box for the first variable
			GUI.Box (new Rect (Screen.width - 280, (Screen.height / 2) - 10, 115, 30), "VARIABLE 1"/*Application.getFirstVariable()*/);

			// Make the text field for the first variable
			var1 = GUI.TextField (new Rect (Screen.width - 150, (Screen.height / 2) - 10, 115, 30), var1, 25);
			
			// Make the box for the second variable
			GUI.Box (new Rect (Screen.width - 280, (Screen.height / 2) + 30, 115, 30), "VARIABLE 2"/*Application.getSecondVariable()*/);
			
			// Make the text field for the second variable
			var2 = GUI.TextField (new Rect (Screen.width - 150, (Screen.height / 2) + 30, 115, 30), var2, 25);
			
			// Make the box for the third variable
			GUI.Box (new Rect (Screen.width - 280, (Screen.height / 2) + 70, 115, 30), "VARIABLE 3"/*Application.getThirdVariable()*/);

			// Make the text field for the third variable
			var3 = GUI.TextField (new Rect (Screen.width - 150, (Screen.height / 2) + 70, 115, 30), var3, 25);

			// Make the box for the fourth variable
			GUI.Box (new Rect (Screen.width - 280, (Screen.height / 2) + 110, 115, 30), "VARIABLE 4"/*Application.getFourthVariable()*/);

			// Make the text field for the fourth variable
			var4 = GUI.TextField (new Rect (Screen.width - 150, (Screen.height / 2) + 110, 115, 30), var4, 25);

			// Make the box for the fifth variable
			GUI.Box (new Rect (Screen.width - 280, (Screen.height / 2) + 150, 115, 30), "VARIABLE 5"/*Application.getFifthVariable()*/);

			// Make the text field for the fifth variable
			var5 = GUI.TextField (new Rect (Screen.width - 150, (Screen.height / 2) + 150, 115, 30), var5, 25);

			// Make the box for the first step
			GUI.Box (new Rect (Screen.width - 280, (Screen.height / 2) + 190, 245, 30), "STEP 1"/*Application.getStep1()*/);

			// Make the box for the first step
			GUI.Box (new Rect (Screen.width - 280, (Screen.height / 2) + 230, 245, 30), "STEP 2"/*Application.getStep2()*/);

			// Make the box for the first step
			GUI.Box (new Rect (Screen.width - 280, (Screen.height / 2) + 270, 245, 30), "STEP 3"/*Application.getStep3()*/);

			// Make the Fire button. If it is pressed, Application.SubmitSolution will be executed
			if (GUI.Button (new Rect (Screen.width - 290, (Screen.height / 2) + 310, 270, 30), "FIRE!!!")) {
					//Application.SubmitSolution();
			}
		}
		endScore = con.getScore ();
		if (endScore > startScore)
			guiTexture.texture = rpNeutral;
		else if (endScore < startScore)
			guiTexture.texture = rpDisappointed;
	}
}
