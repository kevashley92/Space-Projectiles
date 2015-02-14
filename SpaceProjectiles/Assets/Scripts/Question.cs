using UnityEngine;
using System.Collections;

public class Question{
	private string questionString;
	private ProblemGenerator problemVars;
	private Stage[] stageArray;
	private int questNum;
	private int numOfStages;
	private StudentModel studentData;
	// Use this for initialization

	public Question(StudentModel student){
		problemVars = new ProblemGenerator ();
		studentData = student;
		}

	public void generateQuestion(int questionType){
		problemVars = new ProblemGenerator ();
				if (questionType == 1) {
						questNum = 0;
						questionString = "Capt'n!  I have suffered a direct hit!  My calculation systems that we rely on to inform the cannonners has been damaged.  Backup systems" +
								" have been engaged but I have detected problems in my knowledge matrix!  Can you please answer these questions for me to help get my system running again.";
						numOfStages = 6;
						stageArray = new Stage[numOfStages];
						for (int i = 0; i < numOfStages; i++) {
								stageArray [i] = new Stage (questNum, i + 1, problemVars, studentData);
						}
				} else if (questionType == 2) {
						
						int problemSelect = Mathf.RoundToInt (Random.Range (1, 4));
						switch (problemSelect) {
						case 1:
				questionString = "Capt'n!  We are " + problemVars.getInitHeight () + " meters above the pirate ship and " + problemVars.getDistance ().ToString ("#.00") + " meters away!  " +
										"The cannonners need to know what velocity we need to launch at so we can down those scurvy dogs!";
								questNum = 1;
								numOfStages = 19;
								stageArray = new Stage[numOfStages];
								for (int i = 0; i < numOfStages; i++) {
									stageArray [i] = new Stage (questNum, i + 1, problemVars, studentData);
								}
				
								break;
						case 2:
				questionString = "Capt'n! Our altimeter is on the fritz again!  We know our last shot was traveling at " + problemVars.getVelYFin ().ToString ("#.00") + " meters/second" +
					" downwards when it passed their ship.  Also the men report we are " + problemVars.getDistance ().ToString ("#.00") + " meters away.  The connonners are asking at " +
										"what velocity do we need to launch!";
								questNum = 2;
								numOfStages = 19;
								stageArray = new Stage[numOfStages];
								for (int i = 0; i < numOfStages; i++) {
									stageArray [i] = new Stage (questNum, i + 1, problemVars, studentData);
								}
								break;
						case 3:
								questionString = "Capt'n! We are " + problemVars.getInitHeight () + " meters above the pirate ship and our cannonners report they can only launch " +
					"at " + problemVars.getXVel ().ToString ("#.00") + " meters/second.  We need to know how far away they are for some reason I can't think of!";
								questNum = 3;
								numOfStages = 19;
								stageArray = new Stage[numOfStages];
								for (int i = 0; i < numOfStages; i++) {
									stageArray [i] = new Stage (questNum, i + 1, problemVars, studentData);
								}
								break;
						case 4:
				questionString = "Capt'n! Our altimeter is on the fritz again!  Our last shot passed right behind their ship and was traveling at " + problemVars.getVelYFin ().ToString ("#.00") +
					" meters/second downwards when it was on the same level as them.  Also our cannonners report they can only launch at " + problemVars.getXVel ().ToString ("#.00") + 
										" meters/second.  We need to know how far away they are for some reason I can't think of!";
								questNum = 4;
								numOfStages = 19;
								stageArray = new Stage[numOfStages];
								for (int i = 0; i < numOfStages; i++) {
									stageArray [i] = new Stage (questNum, i + 1, problemVars, studentData);
								}
								break;
						case 5:
				//For acceleration not being -9.8.
								break;
						case 6:
				//For acceleration not being -9.8.
								break;
						}
				}
		}
	public string getQuestionString(){
				return questionString;
		}
	public Stage getStage(int stageNum){
				return stageArray [stageNum];
		}
	public int getNumOfStages(){
				return numOfStages;
		}
	public int getQuestNum(){
		return questNum;
		}

	public ProblemGenerator getProblemGen(){
		return problemVars;
		}

}
