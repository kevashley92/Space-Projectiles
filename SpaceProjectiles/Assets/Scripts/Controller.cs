using UnityEngine;
using System.Collections;

public class Controller {
	
	private Stage stage;
	private Question q;
	private string taskString;
	private string questionString;
	private Answers [] allAnswers;
	private int numAnswers;
	private string[] hints;
	private int numHints;
	private StudentModel student;
	private int taskType;
	private int stageType;
	private int score;
	private int nextStage;
	private int hintIndex;

	public Controller() {
		student = new StudentModel ();
		q = new Question (student);
		taskType = 1;
		q.generateQuestion (taskType);
		stage = q.getStage (0);
		stageType = stage.getStageType ();
		taskString = q.getQuestionString ();
		questionString = stage.getStageQuestion ();
		numAnswers = stage.getNumAnswers ();
		allAnswers = new Answers[numAnswers];
		for (int j = 0; j < numAnswers; j++) {
			allAnswers [j] = stage.getAnswer (j);
		}
		shuffleAnswers (allAnswers);
		score = 0;
		numHints = stage.getNumHints ();
		hints = new string[numHints];
		for (int j = 0; j < numHints; j++) {
			hints [j] = stage.getHint (j);
		}
		hintIndex = -1;
		
		//if (score < 25) {
		//	do Question 1 over
		//}
	}

	public void stageStart (int idx, int task) {
		if (idx >= 0) {
			taskType = task;
			stage = q.getStage (idx);
			stageType = stage.getStageType ();
			taskString = q.getQuestionString ();
			questionString = stage.getStageQuestion ();
			numAnswers = stage.getNumAnswers ();
			allAnswers = new Answers[numAnswers];
			for (int j = 0; j < numAnswers; j++) {
				allAnswers [j] = stage.getAnswer (j);
			}
			shuffleAnswers (allAnswers);
			numHints = stage.getNumHints ();
			hints = new string[numHints];
			for (int j = 0; j < numHints; j++) {
				hints [j] = stage.getHint (j);
			}
			hintIndex = -1;
		} else if (task == 1) {
			task++;
			taskType = task;
			idx = 0;
			q.generateQuestion (taskType);
			stage = q.getStage (idx);
			stageType = stage.getStageType ();
			taskString = q.getQuestionString ();
			questionString = stage.getStageQuestion ();
			numAnswers = stage.getNumAnswers ();
			allAnswers = new Answers[numAnswers];
			for (int j = 0; j < numAnswers; j++) {
				allAnswers [j] = stage.getAnswer (j);
			}
			shuffleAnswers (allAnswers);
			numHints = stage.getNumHints ();
			hints = new string[numHints];
			for (int j = 0; j < numHints; j++) {
				hints [j] = stage.getHint (j);
			}
			hintIndex = -1;
		} else {

			if (student.studentModelSum () >= 250){
				Application.LoadLevel ("WinScreen");
			} else {
				GameObject dataHolder = GameObject.FindWithTag ("DataManag");
				BattleData data = dataHolder.GetComponent<BattleData>();
				data.cont = this;
				data.used = true;
				data.score = score;
				Application.LoadLevel("BattleScene");
			}
		}
	}
	
	public void answerQuestion (int idx) {
		bool [] effects = this.stage.getEffectsStudentModel ();
		int increment = 5;
		int decrement = 2;
		if (allAnswers [idx].getIsCorrect ()) {
			if (effects[0])
				student.incUnderstandsConstants (increment);
			if (effects[1])
				student.incManipulatesEquations (increment);
			if (effects[2])
				student.incUnderstandsYacceleration (increment);
			if (effects[3])
				student.incUnderstandsXacceleration (increment);
			if (effects[4])
				student.incUnderstandsXvelocity (increment);
			if (effects[5])
				student.incCorrectlySolvesForT (increment);
			if (effects[6])
				student.incCorrectlySolvesTheEquations (increment);
			score += increment;
		} else {
			if (effects[0])
				student.decUnderstandsConstants (decrement);
			if (effects[1])
				student.decManipulatesEquations (decrement);
			if (effects[2])
				student.decUnderstandsYacceleration (decrement);
			if (effects[3])
				student.decUnderstandsXacceleration (decrement);
			if (effects[4])
				student.decUnderstandsXvelocity (decrement);
			if (effects[5])
				student.decCorrectlySolvesForT (decrement);
			if (effects[6])
				student.decCorrectlySolvesTheEquations (decrement);
			score -= decrement;
		}
		stageStart (allAnswers [idx].getNextStage ()-1, taskType);
	}

	public void choose (int idx) {
		stageStart (allAnswers [idx].getNextStage ()-1, taskType);
	}

	public void fillIn (string value) {
		bool [] effects = this.stage.getEffectsStudentModel ();
		int increment = 5;
		int decrement = 2;
		float resultVal;
		if (!float.TryParse (value, out resultVal)) {
			if (!float.TryParse (allAnswers[0].getAnswerText (), out resultVal)) {
				if ("SF".Equals(value.ToUpper ()) || "UK".Equals(value.ToUpper ())) {
					if (allAnswers[0].getAnswerText ().Equals (value)) {
						if (effects[0])
							student.incUnderstandsConstants (increment);
						if (effects[1])
							student.incManipulatesEquations (increment);
						if (effects[2])
							student.incUnderstandsYacceleration (increment);
						if (effects[3])
							student.incUnderstandsXacceleration (increment);
						if (effects[4])
							student.incUnderstandsXvelocity (increment);
						if (effects[5])
							student.incCorrectlySolvesForT (increment);
						if (effects[6])
							student.incCorrectlySolvesTheEquations (increment);
						score += increment;
						stageStart (allAnswers [0].getNextStage ()-1, taskType);
					} else {
						if (effects[0])
							student.decUnderstandsConstants (decrement);
						if (effects[1])
							student.decManipulatesEquations (decrement);
						if (effects[2])
							student.decUnderstandsYacceleration (decrement);
						if (effects[3])
							student.decUnderstandsXacceleration (decrement);
						if (effects[4])
							student.decUnderstandsXvelocity (decrement);
						if (effects[5])
							student.decCorrectlySolvesForT (decrement);
						if (effects[6])
							student.decCorrectlySolvesTheEquations (decrement);
						score -= decrement;
						if (allAnswers [0].getNextStage () == -1)
							stageStart (allAnswers [0].getNextStage ()-1, taskType);
						else
							stageStart (allAnswers [0].getNextStage ()-2, taskType);
					}
				}
			} else {
				if (effects[0])
					student.decUnderstandsConstants (decrement);
				if (effects[1])
					student.decManipulatesEquations (decrement);
				if (effects[2])
					student.decUnderstandsYacceleration (decrement);
				if (effects[3])
					student.decUnderstandsXacceleration (decrement);
				if (effects[4])
					student.decUnderstandsXvelocity (decrement);
				if (effects[5])
					student.decCorrectlySolvesForT (decrement);
				if (effects[6])
					student.decCorrectlySolvesTheEquations (decrement);
				score -= decrement;
				if (allAnswers [0].getNextStage () == -1)
					stageStart (allAnswers [0].getNextStage ()-1, taskType);
				else
					stageStart (allAnswers [0].getNextStage ()-2, taskType);
			}
		} else {
			if (float.TryParse (allAnswers[0].getAnswerText (), out resultVal)) {
				if (float.Parse(allAnswers[0].getAnswerText ()) == float.Parse (value)) {
					//Send the value to the state saver in case this is the last task.
					GameObject dataHolder = GameObject.FindWithTag ("DataManag");
					BattleData data = dataHolder.GetComponent<BattleData>();
					data.answer = float.Parse (value);
							
					if (effects[0])
						student.incUnderstandsConstants (increment);
					if (effects[1])
						student.incManipulatesEquations (increment);
					if (effects[2])
						student.incUnderstandsYacceleration (increment);
					if (effects[3])
						student.incUnderstandsXacceleration (increment);
					if (effects[4])
						student.incUnderstandsXvelocity (increment);
					if (effects[5])
						student.incCorrectlySolvesForT (increment);
					if (effects[6])
						student.incCorrectlySolvesTheEquations (increment);
					score += increment;
					stageStart (allAnswers [0].getNextStage ()-1, taskType);
				} else {
					//Send the value to the state saver in case this is the last task.
					GameObject dataHolder = GameObject.FindWithTag ("DataManag");
					BattleData data = dataHolder.GetComponent<BattleData>();
					data.answer = float.Parse (value);

					if (effects[0])
						student.decUnderstandsConstants (decrement);
					if (effects[1])
						student.decManipulatesEquations (decrement);
					if (effects[2])
						student.decUnderstandsYacceleration (decrement);
					if (effects[3])
						student.decUnderstandsXacceleration (decrement);
					if (effects[4])
						student.decUnderstandsXvelocity (decrement);
					if (effects[5])
						student.decCorrectlySolvesForT (decrement);
					if (effects[6])
						student.decCorrectlySolvesTheEquations (decrement);
					score -= decrement;
					if (allAnswers [0].getNextStage () == -1)
						stageStart (allAnswers [0].getNextStage ()-1, taskType);
					else
						stageStart (allAnswers [0].getNextStage ()-2, taskType);
				}
			} else {
				//Send the value to the state saver in case this is the last task.
				GameObject dataHolder = GameObject.FindWithTag ("DataManag");
				BattleData data = dataHolder.GetComponent<BattleData>();
				data.answer = float.Parse (value);
				
				if (effects[0])
					student.decUnderstandsConstants (decrement);
				if (effects[1])
					student.decManipulatesEquations (decrement);
				if (effects[2])
					student.decUnderstandsYacceleration (decrement);
				if (effects[3])
					student.decUnderstandsXacceleration (decrement);
				if (effects[4])
					student.decUnderstandsXvelocity (decrement);
				if (effects[5])
					student.decCorrectlySolvesForT (decrement);
				if (effects[6])
					student.decCorrectlySolvesTheEquations (decrement);
				score -= decrement;
				if (allAnswers [0].getNextStage () == -1)
					stageStart (allAnswers [0].getNextStage ()-1, taskType);
				else
					stageStart (allAnswers [0].getNextStage ()-2, taskType);
			}
		}
	}
	
	public void selectMultiple(int idx) {
		int totalRightChoices = 0;
		for (int i = 0; i < numAnswers; i++) {
			if (allAnswers[i].getIsCorrect ())
				totalRightChoices++;
		}
	}

	public void skipQuestion(int idx) {
		stageStart (allAnswers [idx].getNextStage ()-1, taskType);
	}

	public void useHint (int timesUsed) {
		if (timesUsed >= 1 && timesUsed < numHints)
			score -= 2;
		hintIndex++;
	}
	public Question getQuesData(){
		return this.q;
		}
	public string getQuestion () {
		return this.questionString;
	}

	public Answers [] getAnswers () {
		return this.allAnswers;
	}

	public int getNumAnswers () {
		return this.numAnswers;
	}

	public string [] getHints () {
		return this.hints;
	}

	public int getNumHints () {
		return this.numHints;
	}

	public int getHintIndex () {
		return this.hintIndex;
	}

	public string getTask () {
		return this.taskString;
	}

	public int getTaskType () {
		return this.taskType;
	}

	public int getStageType () {
		return this.stageType;
	}

	public int getScore () {
		return this.score;
	}
	public void returnToQuiz(){
		GameObject dataHolder = GameObject.FindWithTag ("DataManag");
		BattleData data = dataHolder.GetComponent<BattleData>();
		int idx = 0;
		score = data.score;
		q.generateQuestion (taskType);
		stage = q.getStage (idx);
		stageType = stage.getStageType ();
		taskString = q.getQuestionString ();
		questionString = stage.getStageQuestion ();
		numAnswers = stage.getNumAnswers ();
		allAnswers = new Answers[numAnswers];
		for (int j = 0; j < numAnswers; j++) {
			allAnswers [j] = stage.getAnswer (j);
		}
		shuffleAnswers (allAnswers);
		numHints = stage.getNumHints ();
		hints = new string[numHints];
		for (int j = 0; j < numHints; j++) {
			hints [j] = stage.getHint (j);
		}
		hintIndex = -1;
	}

	void shuffleAnswers(Answers[] answers) {
		for (int i = answers.Length - 1; i >= 0; i--) {
			int swapIndex  = Random.Range (0, answers.Length - 1);
			if (swapIndex != i) {
				Answers tmp = answers[swapIndex];
				answers[swapIndex] = answers[i];
				answers[i] = tmp;
			}
		}
	}
	public ProblemGenerator getProb(){
			return this.q.getProblemGen ();
		}

}
