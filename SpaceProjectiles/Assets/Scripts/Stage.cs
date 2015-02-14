using UnityEngine;
using System.Collections;

public class Stage{

	public const int MULTI_CHOICE = 0;
	public const int FILL_IN = 1;
	public const int CHOICE = 2;
	public const int SELECT_MULTIPLE = 3;
	public const int SKIP = 4;

	private int stageType;
	private string stageQuestion;
	private Answers[] answer;
	private int numberOfAnswers;
	private string[] hint;
	private int numberOfHints;
	//0 = Constants, 1 = Manipulates Equations, 2 = Y acc, 3 = X acc, 4 = X vel, 5 = SolveT 6 = Solve Equation
	private bool[] effectsStudentModel = new bool[7];

	public Stage(int type, int stage, ProblemGenerator problemData, StudentModel studentData){
		effectsStudentModel[0] = false;
		effectsStudentModel[1] = false;
		effectsStudentModel[2] = false;
		effectsStudentModel[3] = false;
		effectsStudentModel[4] = false;
		effectsStudentModel[5] = false;
		effectsStudentModel[6] = false;
		if (type == 0) {
			switch (stage){
			case 1:
				stageType = MULTI_CHOICE;
				stageQuestion = "Is there any force on an object in the horizontal plane that would slow a projectile down?";
				numberOfAnswers = 2;
				answer = new Answers[numberOfAnswers];
				answer[0] = new Answers(true, "No.", 2);
				answer[1] = new Answers(false, "Yes.", 1);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Since this is space and there is no air resistance...";
				hint [1] = "Gravity only effects the velocity in the vertical plane.";
				hint [2] = "The answer is: " + answer [0].getAnswerText ();
				effectsStudentModel[3] = true;
				break;
			case 2:
				stageType = MULTI_CHOICE;
				stageQuestion = "Since there is no force on an object in the horizontal plane that would slow it down, would the" +
					" velocity be considered a constant?";
				numberOfAnswers = 2;
				answer = new Answers[numberOfAnswers];
				answer[0] = new Answers(true, "Yes.", 3);
				answer[1] = new Answers(false, "No.", 2);
				numberOfHints = 2;
				hint = new string[numberOfHints];
				hint [0] = "We have determined that there is no force slowing it down so does it ever change?";
				hint [1] = "The answer is: " + answer [0].getAnswerText ();
				effectsStudentModel[0] = true;
				effectsStudentModel[4] = true;
				break;
			case 3:
				stageType = MULTI_CHOICE;
				stageQuestion = "What is the equation we would use to determine an objects velocity? X = distance, T = time, A = acceleration";
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer[0] = new Answers(true, "v = X(change) / T(change)", 4);
				answer[1] = new Answers(false, "v = T(change) / X(change)", 3);
				answer[2] = new Answers(false, "v = X(change) / A(change)", 3);
				answer[3] = new Answers(false, "v = A(change) / X(change)", 3);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Think about the units for velocity.";
				hint [1] = "The units for velocity describe a distance and a time.";
				hint [2] = "The answer is: " + answer [0].getAnswerText ();
				effectsStudentModel[4] = true;
				break;
			case 4:
				stageType = MULTI_CHOICE;
				stageQuestion = "So the general equation to determine how far an object travels is?";
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer[0] = new Answers(true, "x(final) = x(initial) + v*t", 5);
				answer[1] = new Answers(false, "x(final) = x(initial) * t + v", 4);
				answer[2] = new Answers(false, "x(final) = x(initial) * v + t", 4);
				answer[3] = new Answers(false, "x(final) = x(initial) * v * t", 4);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Remember the previous equation we determined v = x(change) / t(change)";
				hint [1] = "What would the various equations look like if x(initial) was 0?";
				hint [2] = "The answer is: " + answer [0].getAnswerText ();
				effectsStudentModel[1] = true;
				break;
			case 5:
				stageType = MULTI_CHOICE;
				stageQuestion = "How about gravity (acceleration)?  Is it a constant?";
				numberOfAnswers = 2;
				answer = new Answers[numberOfAnswers];
				answer[0] = new Answers(true, "Yes... Well for our purposes.", 6);
				answer[1] = new Answers(false, "No.", 5);
				numberOfHints = 2;
				hint = new string[numberOfHints];
				hint [0] = "Remember the previous equation we determined v = x(change) / t(change)";
				hint [1] = "The answer is: " + answer [0].getAnswerText ();
				effectsStudentModel[0] = true;
				break;
			case 6:
				stageType = MULTI_CHOICE;
				stageQuestion = "What is the equation we would use to determine acceleration? A = acceleration, V = velocity, T = time";
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer[0] = new Answers(true, "A = V(change) / T(change)", -1);
				answer[1] = new Answers(false, "A = T(change) / V(change)", 6);
				answer[2] = new Answers(false, "A = X(change) / T(change)", 6);
				answer[3] = new Answers(false, "A = T(change) / X(change)", 6);
				numberOfHints = 1;
				hint = new string[numberOfHints];
				hint [0] = "Sorry no hints are available.";
				effectsStudentModel[1] = true;
				effectsStudentModel[2] = true;
				effectsStudentModel[3] = true;
				break;
			}
		}


		//find Vix ay, y, viy, x
		if (type == 1){
		switch (stage) {
				//General givens question.
			case 1:
				if (studentData.getUnderstandsConstants() < 25){
					stageType = MULTI_CHOICE;
					stageQuestion = "The very first thing you should do when you examine a problem is?";
					//answers and which is correct.  Placed randomly. edit, do the random order in the controller.
					numberOfAnswers = 4;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "Identify your givens and what the problem is asking for.", 2);
					answer [1] = new Answers (false, "Fire a warning shot across their bow!", 1); //Dummy answer
					answer [2] = new Answers (false, "Use non-determinism to argue that none of this really matters or it does.", 1); //Dummy answer
					answer [3] = new Answers (false, "Determine the velocity!", 1); //Dummy answer
					//Hints, should be set in sequential order.
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Knowing what info you have and knowing where you are going is really important.";
					hint [1] = "The answer is: " + answer [0].getAnswerText ();
					effectsStudentModel[0] = true;
				} else {
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 2);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				}

				break;
				//Select all the givens
			case 2:
				/*if (studentData.getUnderstandsConstants() < 45){
					stageType = SELECT_MULTIPLE;
					stageQuestion = "Select all givens and constants to enter data for.";
					numberOfAnswers = 10;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "Acceleration in the y direction.", 3);
					answer [1] = new Answers (true, "Acceleration in the x direction.", 3);
					answer [2] = new Answers (true, "Initial Velocity in the y direction.", 3);
					answer [3] = new Answers (true, "Enter the height difference between the ships.", 3);
					answer [4] = new Answers (true, "Enter the distance between the two ships.", 3);
					answer [5] = new Answers (false, "The color of the ship.", 2);
					answer [6] = new Answers (false, "Initial Velocity in the x direction.", 2);
					answer [7] = new Answers (false, "Final velocity in the x direction.", 2);
					answer [8] = new Answers (false, "Final velocity in the y direction.", 2);
					answer [9] = new Answers (false, "Total flight time", 2);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint [0] = "Sorry no hints are available.";
					effectsStudentModel[0] = true;
				} else {*/
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 3);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				//}
				break;
				//Acceleration in y
			case 3:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getAccY ().ToString ("#.00"), 4);
				if (studentData.getUnderstandsConstants() < 35 || studentData.getUnderstandsYacceleration() < 40){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "On earth this is a negative value.";
					hint [2] = "This value is often assumed as a constant even if not written. Known as gravity sometimes.";
					hint [3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() < 35){
					stageQuestion = "Enter the acceleration in the y direction. Enter SF if this is what you are solving for, enter UK if unknown.";
				} else {
					stageQuestion = "Enter the acceleration in the y direction.";
				}

				effectsStudentModel[0] = true;
				effectsStudentModel[2] = true;
				break;
				//Acceleration in x
			case 4:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, ("0.00")/*problemData.getAccX ().ToString ("#.00")*/, 5);
				if (studentData.getUnderstandsConstants() < 35 || studentData.getUnderstandsXacceleration() < 40){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Does the projectile accelerate or decelerate in the x direction?";
					hint[1] = "This is often not included in the text.";
					hint[2] = "Depending on this value of some of the equations get easier to work with.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() < 35){
					stageQuestion = "Enter the acceleration in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				} else {
					stageQuestion = "Enter the acceleration in the x direction.";
				}

				effectsStudentModel[0] = true;
				effectsStudentModel[3] = true;
				break;
				//Initial velocity in y
			case 5:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, ("0.00")/*problemData.getYVel ().ToString ("#.00")*/, 6);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "This is often not included in the text.";
					hint[1] = "This is the maximum height of the object.";
					hint[2] = "Remember the shot's initial direction is completely horizontal.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is the maximum height of the object.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the initial velocity in the y direction.";
				} else {
					stageQuestion = "Enter the initial velocity in the y direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}

				effectsStudentModel[0] = true;
				break;
				//height
			case 6:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getInitHeight ().ToString ("#.00"), 7);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Read the text carefully.";
					hint[1] = "This should be clearly stated in the text.  Either as one value or two.";
					hint[2] = "If you view the y axis as the ground, this is how far above it you are.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Read the text carefully.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the height differance between the ships.";
				} else {
					stageQuestion = "Enter the height differance between the ships.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}


				effectsStudentModel[0] = true;
				break;
				//distance
			case 7:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getDistance ().ToString ("#.00"), 8);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Read the text carefully.";
					hint[1] = "This should be clearly stated in the text.  Either as one value or two.";
					hint[2] = "This would be the offset one ship is along the x axis from the origin.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Read the text carefully.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the distance between the two ships.";
				} else {
					stageQuestion = "Enter the distance between the two ships.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}


				effectsStudentModel[0] = true;
				break;
				//initial velocity in x direction
			case 8:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "SF", 9);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 3;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text";
					hint [1] = "What is poly asking you to solve for?";
					hint [2] = "The correct answer is SF";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text";
					hint [1] = "The correct answer is SF";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() < 35){
					stageQuestion = "Enter the initial velocity of the projectile in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				} else {
					stageQuestion = "Enter the initial velocity of the projectile in the x direction.";
				}

				effectsStudentModel[0] = true;
				effectsStudentModel[4] = true;
				break;
				//final velocity in y
			case 9:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "UK", 10);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "Does this have a constant value?  Is it stated in the text?";
					hint [1] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [2] = "Re-examine the main text is this value listed or implied?";
					hint [3] = "The correct answer is UK";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text is this value listed or implied?";
					hint [1] = "The correct answer is UK";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the final velocity of the projectile in the y direction.";
				} else {
					stageQuestion = "Enter the final velocity of the projectile in the y direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}


				effectsStudentModel[0] = true;
				break;
				//final velocity in x
			case 10:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "UK", 11);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "This is a bit of a trick question.  What do we know about initial velocities and final?";
					hint [1] = "Is there a force acting upon the x velocity?  If not it should be the same as the initial.";
					hint [2] = "We don't know the initial velocity in the x direction so...";
					hint [3] = "The correct answer is UK";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is a bit of a trick question.  What do we know about initial velocities and final?";
					hint [1] = "The correct answer is UK";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the final velocity of the projectile in the x direction.";
				} else {
					stageQuestion = "Enter the final velocity of the projectile in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}

				effectsStudentModel[0] = true;
				effectsStudentModel[4] = true;
				break;
				//time
			case 11:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "SF", 12);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 3;
					hint = new string[numberOfHints];
					hint [0] = "Does this have a constant value?  Is it stated in the text?  Is this something you could be solving for?";
					hint [1] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [2] = "The correct answer is SF";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [1] = "The correct answer is SF";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the total flight time for the object.";
				} else {
					stageQuestion = "Enter the total flight time for the object.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}

				effectsStudentModel[0] = true;
				effectsStudentModel[5] = true;
				break;
				//choice of equations for y
			case 12:  //jump here
				if (studentData.getManipulatesEquations() > 45){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 15);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else{
					stageQuestion = "Which set of equations would you like to use.";
					stageType = CHOICE;
					stageQuestion = "Which set of equations would you like to use.";
					numberOfAnswers = 2;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "y = 1/2*a*t^2", 13);
					answer [1] = new Answers (true, "Vfy^2 = Viy^2 + 2*a*y and Vfy = Viy + a*t", 14);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint [0] = "Sorry no hints are available.";
				}

				break;
				//solving equation for y
			case 13:
				//If answer 0 for case 8 was chosen go here, why I think we need a stage tree.
				stageType = MULTI_CHOICE;
				stageQuestion = "What is the correct equation for denoting the value we need to solve for.";
				numberOfAnswers = 3;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "t = sqrt(2*y / a)", 15);
				answer [1] = new Answers (false, "y = 1/2 * a*t^2", 13);
				answer [2] = new Answers (false, "a = 2y / t^2", 13);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Ask yourself what are you trying to solve for.";
				hint [1] = "If you know what you are trying to solve for, manipulate the equation so that you have only that value on one side.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[1] = true;
				break;
				//solving equation for y
			case 14:
				//If answe+ase 8 was chose go here, why I think we need a stage tree.
				stageType = MULTI_CHOICE;
				stageQuestion = "What are the correct equations for denoting the value we need to solve for.";
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "Vfy = sqrt(Viy^2 + 2*a*y) and t = (Vfy - Viy) / a", 15);
				answer [1] = new Answers (false, "y = (Vfy^2 - Viy^2) / 2a and t = (Vfy - Viy) / a", 14);
				answer [2] = new Answers (false, "Vfy = sqrt(Viy^2 + 2*a*y) and a = (Vfy -Viy) / t", 14);
				answer [3] = new Answers (false, "y = (Vfy^2 - Viy^2) / 2a and a = (Vfy -Viy) / t", 14);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Ask yourself what are you trying to solve for.";
				hint [1] = "If you know what you are trying to solve for, manipulate the equation so that you have only that value on one side.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[1] = true;
				break;
				//solve for time
			case 15:
				stageType = FILL_IN;
				stageQuestion = "Enter the value of t (time).";
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getTime ().ToString ("#.00"), 16);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Check your values and make sure you entered everything correctly.";
				hint [1] = "Make sure you did not round too much.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[5] = true;
				break;
				//question about acceleration along x
			case 16:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 2;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "No.", 17);
				answer [1] = new Answers (false, "Yes.", 16);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Negating wind resistance since we are in space, what would cause the shot to slow down in the x direction?";
				hint [1] = "An object in motion tends to stay in motion unless acted upon...";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				if (studentData.getUnderstandsXacceleration() == 50 || studentData.getUnderstandsXvelocity() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 17);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Does the shot slow down at all along the x axis?";
				}
				effectsStudentModel[3] = true;
				effectsStudentModel[4] = true;
				break;
				//solving equation for x
			case 17:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 3;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "1/2*a*t^2", 18);
				answer [1] = new Answers (false, "x*t", 17);
				answer [2] = new Answers (false, "Vix", 17);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "What happens if you multiply anything by 0?";
				hint [1] = "Since there is no change to the velocity the acceleration must be 0.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				if (studentData.getUnderstandsXacceleration() == 50 || studentData.getManipulatesEquations() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 18);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Since the ball does not slow down along the x axis what part of this equation is not needed: Vix = x*t - 1/2*a*t^2";
				}
				effectsStudentModel[1] = true;
				effectsStudentModel[3] = true;
				break;
				//solving equation for x
			case 18:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "Vix = x*t", 19);
				answer [1] = new Answers (false, "Vix = x*t - 1/2*a*t^2", 18);
				answer [2] = new Answers (false, "x = Vix / t", 18);
				answer [3] = new Answers (false, "t = Vix / x", 18);
				numberOfHints = 1;
				hint = new string[numberOfHints];
				hint [0] = "Sorry no hints are available.";
				if (studentData.getManipulatesEquations() > 30){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 19);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Since we dont need that part, set up Vix = x*t - 1/2*a*t^2 for our purposes.";
				}
				effectsStudentModel[1] = true;
				break;
				//complete the question
			case 19:
				stageType = FILL_IN;
				stageQuestion = "What is the initial velocity needed to hit the target?";
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer[0] = new Answers(true, problemData.getXVel().ToString("#.00"), -1);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Check your values and make sure you entered everything correctly.";
				hint [1] = "Make sure you did not round too much.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[6] = true;
				break;
			}

		}

		//Find Vix Vfy, Viy, x, ay
		if (type == 2){
			switch (stage) {
				//General givens question.
			case 1:
				if (studentData.getUnderstandsConstants() < 25){
					stageType = MULTI_CHOICE;
					stageQuestion = "The very first thing you should do when you examine a problem is?";
					//answers and which is correct.  Placed randomly. edit, do the random order in the controller.
					numberOfAnswers = 4;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "Identify your givens and what the problem is asking for.", 2);
					answer [1] = new Answers (false, "Fire a warning shot across their bow!", 1); //Dummy answer
					answer [2] = new Answers (false, "Use non-determinism to argue that none of this really matters or it does.", 1); //Dummy answer
					answer [3] = new Answers (false, "Determine the velocity!", 1); //Dummy answer
					//Hints, should be set in sequential order.
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Knowing what info you have and knowing where you are going is really important.";
					hint [1] = "The answer is: " + answer [0].getAnswerText ();
					effectsStudentModel[0] = true;
				} else {
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 2);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				}
				
				break;
				//Select all the givens
			case 2:
				/*if (studentData.getUnderstandsConstants() < 45){
					stageType = SELECT_MULTIPLE;
					stageQuestion = "Select all givens and constants to enter data for.";
					numberOfAnswers = 10;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "Acceleration in the y direction.", 3);
					answer [1] = new Answers (true, "Acceleration in the x direction.", 3);
					answer [2] = new Answers (true, "Initial Velocity in the y direction.", 3);
					answer [3] = new Answers (false, "Enter the height difference between the ships.", 2);
					answer [4] = new Answers (true, "Enter the distance between the two ships.", 3);
					answer [5] = new Answers (false, "The color of the ship.", 2);
					answer [6] = new Answers (false, "Initial Velocity in the x direction.", 2);
					answer [7] = new Answers (false, "Final velocity in the x direction.", 2);
					answer [8] = new Answers (true, "Final velocity in the y direction.", 3);
					answer [9] = new Answers (false, "Total flight time", 2);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint [0] = "Sorry no hints are available.";
					effectsStudentModel[0] = true;
				} else {*/
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 3);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				//}
				break;
				//Acceleration in y
			case 3:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getAccY ().ToString ("#.00"), 4);
				if (studentData.getUnderstandsConstants() < 35 || studentData.getUnderstandsYacceleration() < 40){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "On earth this is a negative value.";
					hint [2] = "This value is often assumed as a constant even if not written. Known as gravity sometimes.";
					hint [3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the acceleration in the y direction.";
				} else {
					stageQuestion = "Enter the acceleration in the y direction. Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[2] = true;
				break;
				//Acceleration in x
			case 4:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, ("0.00")/*problemData.getAccX ().ToString ("#.00")*/, 5);
				if (studentData.getUnderstandsConstants() < 35 || studentData.getUnderstandsXacceleration() < 40){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Does the projectile accelerate or decelerate in the x direction?";
					hint[1] = "This is often not included in the text.";
					hint[2] = "Depending on this value of some of the equations get easier to work with.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the acceleration in the x direction.";
				} else {
					stageQuestion = "Enter the acceleration in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[3] = true;
				break;
				//Initial velocity in y
			case 5:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, ("0.00")/*problemData.getYVel ().ToString ("#.00")*/, 6);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "This is often not included in the text.";
					hint[1] = "This is the maximum height of the object.";
					hint[2] = "Remember the shot's initial direction is completely horizontal.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is the maximum height of the object.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the initial velocity in the y direction.";
				} else {
					stageQuestion = "Enter the initial velocity in the y direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				break;
				//height
			case 6:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "UK", 7);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "Does this have a constant value?  Is it stated in the text?";
					hint [1] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [2] = "Re-examine the main text is this value listed or implied?";
					hint [3] = "The correct answer is UK";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [1] = "The correct answer is UK";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the height differance between the ships.";
				} else {
					stageQuestion = "Enter the height differance between the ships.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				
				effectsStudentModel[0] = true;
				break;
				//distance
			case 7:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getDistance ().ToString ("#.00"), 8);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Read the text carefully.";
					hint[1] = "This should be clearly stated in the text.  Either as one value or two.";
					hint[2] = "This would be the offset one ship is along the x axis from the origin.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Read the text carefully.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the distance between the two ships.";
				} else {
					stageQuestion = "Enter the distance between the two ships.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				
				effectsStudentModel[0] = true;
				break;
				//initial velocity in x direction
			case 8:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "SF", 9);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 3;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text";
					hint [1] = "What is poly asking you to solve for?";
					hint [2] = "The correct answer is SF";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text";
					hint [1] = "The correct answer is SF";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the initial velocity of the projectile in the x direction.";
				} else {
					stageQuestion = "Enter the initial velocity of the projectile in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[4] = true;
				break;
				//final velocity in y
			case 9:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getVelYFin().ToString ("#.00"), 10);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Read the text carefully.";
					hint[1] = "This should be clearly stated in the text.";
					hint[2] = "This would be the speed the shot is going when it passes what would be the \"ground\" level.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text is this value listed or implied?";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the final velocity of the projectile in the y direction.";
				} else {
					stageQuestion = "Enter the final velocity of the projectile in the y direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				
				effectsStudentModel[0] = true;
				break;
				//final velocity in x
			case 10:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "UK", 11);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "This is a bit of a trick question.  What do we know about initial velocities and final?";
					hint [1] = "Is there a force acting upon the x velocity?  If not it should be the same as the initial.";
					hint [2] = "We don't know the initial velocity in the x direction so...";
					hint [3] = "The correct answer is UK";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is a bit of a trick question.  What do we know about initial velocities and final?";
					hint [1] = "The correct answer is UK";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the final velocity of the projectile in the x direction.";
				} else {
					stageQuestion = "Enter the final velocity of the projectile in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[4] = true;
				break;
				//time
			case 11:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "SF", 12);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 3;
					hint = new string[numberOfHints];
					hint [0] = "Does this have a constant value?  Is it stated in the text?  Is this something you could be solving for?";
					hint [1] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [2] = "The correct answer is SF";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [1] = "The correct answer is SF";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the total flight time for the object.";
				} else {
					stageQuestion = "Enter the total flight time for the object.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[5] = true;
				break;
				//choice of equations for y
			case 12:  //jump here
				if (studentData.getManipulatesEquations() > 45){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 15);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else{
					stageQuestion = "Which set of equations would you like to use.";
					stageType = CHOICE;
					stageQuestion = "Which set of equations would you like to use.";
					numberOfAnswers = 2;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "Vfy = Viy + a*t", 13);
					answer [1] = new Answers (true, "Vfy^2 = Viy^2 + 2*a*y and y = 1/2 * a * t^2", 14);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint [0] = "Sorry no hints are available.";
				}
				
				break;
				//solving equation for y
			case 13:
				//If answer 0 for case 8 was chosen go here, why I think we need a stage tree.
				stageType = MULTI_CHOICE;
				stageQuestion = "What is the correct equation for denoting the value we need to solve for.";
				numberOfAnswers = 3;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "t = (Vfy - Viy) / a", 15);
				answer [1] = new Answers (false, "Viy = Vfy - a*t", 13);
				answer [2] = new Answers (false, "a = (Vfy - Viy) / t", 13);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Ask yourself what are you trying to solve for.";
				hint [1] = "If you know what you are trying to solve for, manipulate the equation so that you have only that value on one side.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[1] = true;
				break;
				//solving equation for y
			case 14:
				//If answe+ase 8 was chose go here, why I think we need a stage tree.
				stageType = MULTI_CHOICE;
				stageQuestion = "What are the correct equations for denoting the value we need to solve for.";
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "y = (Vfy^2 - Viy^2) / 2a and t = sqrt(2y / a)", 15);
				answer [1] = new Answers (false, "y = (Vfy^2 - Viy^2) / 2a and a = (Vfy - Viy) / t", 14);
				answer [2] = new Answers (false, "Vfy = sqrt(Viy^2 + 2*a*y) and t = (Vfy -Viy) / a", 14);
				answer [3] = new Answers (false, "Vfy = sqrt(Viy^2 + 2*a*y) and a = (Vfy -Viy) / t", 14);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Ask yourself what are you trying to solve for.";
				hint [1] = "If you know what you are trying to solve for, manipulate the equation so that you have only that value on one side.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[1] = true;
				break;
				//solve for time
			case 15:
				stageType = FILL_IN;
				stageQuestion = "Enter the value of t (time).";
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getTime ().ToString ("#.00"), 16);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Check your values and make sure you entered everything correctly.";
				hint [1] = "Make sure you did not round too much.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[5] = true;
				break;
				//question about acceleration along x
			case 16:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 2;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "No.", 17);
				answer [1] = new Answers (false, "Yes.", 16);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Negating wind resistance since we are in space, what would cause the shot to slow down in the x direction?";
				hint [1] = "An object in motion tends to stay in motion unless acted upon...";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				if (studentData.getUnderstandsXacceleration() == 50 || studentData.getUnderstandsXvelocity() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 17);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Does the shot slow down at all along the x axis?";
				}
				effectsStudentModel[3] = true;
				effectsStudentModel[4] = true;
				break;
				//solving equation for x
			case 17:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 3;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "1/2*a*t^2", 18);
				answer [1] = new Answers (false, "x*t", 17);
				answer [2] = new Answers (false, "Vix", 17);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "What happens if you multiply anything by 0?";
				hint [1] = "Since there is no change to the velocity the acceleration must be 0.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				if (studentData.getUnderstandsXacceleration() == 50 || studentData.getManipulatesEquations() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 18);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Since the ball does not slow down along the x axis what part of this equation is not needed: Vix = x*t - 1/2*a*t^2";
				}
				effectsStudentModel[1] = true;
				effectsStudentModel[3] = true;
				break;
				//solving equation for x
			case 18:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "Vix = x*t", 19);
				answer [1] = new Answers (false, "Vix = x*t - 1/2*a*t^2", 18);
				answer [2] = new Answers (false, "x = Vix / t", 18);
				answer [3] = new Answers (false, "t = Vix / x", 18);
				numberOfHints = 1;
				hint = new string[numberOfHints];
				hint [0] = "Sorry no hints are available.";
				if (studentData.getManipulatesEquations() > 30){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 19);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Since we dont need that part, set up Vix = x*t - 1/2*a*t^2 for our purposes.";
				}
				effectsStudentModel[1] = true;
				break;
				//complete the question
			case 19:
				stageType = FILL_IN;
				stageQuestion = "What is the initial velocity needed to hit the target?";
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer[0] = new Answers(true, problemData.getXVel().ToString("#.00"), -1);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Check your values and make sure you entered everything correctly.";
				hint [1] = "Make sure you did not round too much.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[6] = true;
				break;
			}
			
		}

	//find x given ay, y, vi
		if (type == 3){
			switch (stage) {
				//General givens question.
			case 1:
				if (studentData.getUnderstandsConstants() < 25){
					stageType = MULTI_CHOICE;
					stageQuestion = "The very first thing you should do when you examine a problem is?";
					//answers and which is correct.  Placed randomly. edit, do the random order in the controller.
					numberOfAnswers = 4;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "Identify your givens and what the problem is asking for.", 2);
					answer [1] = new Answers (false, "Fire a warning shot across their bow!", 1); //Dummy answer
					answer [2] = new Answers (false, "Use non-determinism to argue that none of this really matters or it does.", 1); //Dummy answer
					answer [3] = new Answers (false, "Determine the velocity!", 1); //Dummy answer
					//Hints, should be set in sequential order.
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Knowing what info you have and knowing where you are going is really important.";
					hint [1] = "The answer is: " + answer [0].getAnswerText ();
					effectsStudentModel[0] = true;
				} else {
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 2);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				}
				
				break;
				//Select all the givens
			case 2:
				/*if (studentData.getUnderstandsConstants() < 45){
					stageType = SELECT_MULTIPLE;
					stageQuestion = "Select all givens and constants to enter data for.";
					numberOfAnswers = 10;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "Acceleration in the y direction.", 3);
					answer [1] = new Answers (true, "Acceleration in the x direction.", 3);
					answer [2] = new Answers (true, "Initial Velocity in the y direction.", 3);
					answer [3] = new Answers (true, "Enter the height difference between the ships.", 3);
					answer [4] = new Answers (false, "Enter the distance between the two ships.", 2);
					answer [5] = new Answers (false, "The color of the ship.", 2);
					answer [6] = new Answers (true, "Initial Velocity in the x direction.", 3);
					answer [7] = new Answers (true, "Final velocity in the x direction.", 3);
					answer [8] = new Answers (false, "Final velocity in the y direction.", 2);
					answer [9] = new Answers (false, "Total flight time", 2);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint [0] = "Sorry no hints are available.";
					effectsStudentModel[0] = true;
				} else {*/
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 3);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				//}
				break;
				//Acceleration in y
			case 3:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getAccY ().ToString ("#.00"), 4);
				if (studentData.getUnderstandsConstants() < 35 || studentData.getUnderstandsYacceleration() < 40){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "On earth this is a negative value.";
					hint [2] = "This value is often assumed as a constant even if not written. Known as gravity sometimes.";
					hint [3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the acceleration in the y direction.";
				} else {
					stageQuestion = "Enter the acceleration in the y direction. Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[2] = true;
				break;
				//Acceleration in x
			case 4:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, ("0.00")/*problemData.getAccX ().ToString ("#.00")*/, 5);
				if (studentData.getUnderstandsConstants() < 35 || studentData.getUnderstandsXacceleration() < 40){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Does the projectile accelerate or decelerate in the x direction?";
					hint[1] = "This is often not included in the text.";
					hint[2] = "Depending on this value some of of the equations get easier to work with.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the acceleration in the x direction.";
				} else {
					stageQuestion = "Enter the acceleration in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[3] = true;
				break;
				//Initial velocity in y
			case 5:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, ("0.00")/*problemData.getYVel ().ToString ("#.00")*/, 6);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "This is often not included in the text.";
					hint[1] = "This is the maximum height of the object.";
					hint[2] = "Remember the shot's initial direction is completely horizontal.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is the maximum height of the object.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the initial velocity in the y direction.";
				} else {
					stageQuestion = "Enter the initial velocity in the y direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				break;
				//height
			case 6:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getInitHeight ().ToString ("#.00"), 7);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Read the text carefully.";
					hint[1] = "This should be clearly stated in the text.  Either as one value or two.";
					hint[2] = "If you view the y axis as the ground, this is how far above it you are.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Read the text carefully.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the height differance between the ships.";
				} else {
					stageQuestion = "Enter the height differance between the ships.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				
				effectsStudentModel[0] = true;
				break;
				//distance
			case 7:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "SF", 8);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 3;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text";
					hint [1] = "What is poly asking you to solve for?";
					hint [2] = "The correct answer is SF";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text";
					hint [1] = "The correct answer is SF";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the distance between the two ships.";
				} else {
					stageQuestion = "Enter the distance between the two ships.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				
				effectsStudentModel[0] = true;
				break;
				//initial velocity in x direction
			case 8:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getXVel().ToString("#.00"), 9);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Read the text carefully.";
					hint[1] = "This should be clearly stated in the text.  Remember that there is no acceleration in x so this could be equal to another value.";
					hint[2] = "This is considered the speed of the object.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text";
					hint [1] = "The correct answer is " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the initial velocity of the projectile in the x direction.";
				} else {
					stageQuestion = "Enter the initial velocity of the projectile in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[4] = true;
				break;
				//final velocity in y
			case 9:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "UK", 10);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "Does this have a constant value?  Is it stated in the text?";
					hint [1] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [2] = "Re-examine the main text is this value listed or implied?";
					hint [3] = "The correct answer is UK";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text is this value listed or implied?";
					hint [1] = "The correct answer is UK";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the final velocity of the projectile in the y direction.";
				} else {
					stageQuestion = "Enter the final velocity of the projectile in the y direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				
				effectsStudentModel[0] = true;
				break;
				//final velocity in x
			case 10:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getXVel().ToString("#.00"), 11);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "This is a bit of a trick question.  What do we know about initial velocities and final?";
					hint [1] = "Is there a force acting upon the x velocity?  If not it should be the same as the initial.";
					hint [2] = "If we know the initial velocity then...";
					hint [3] = "The correct answer is " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is a bit of a trick question.  What do we know about initial velocities and final?";
					hint [1] = "The correct answer is " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the final velocity of the projectile in the x direction.";
				} else {
					stageQuestion = "Enter the final velocity of the projectile in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[4] = true;
				break;
				//time
			case 11:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "SF", 12);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 3;
					hint = new string[numberOfHints];
					hint [0] = "Does this have a constant value?  Is it stated in the text?  Is this something you could be solving for?";
					hint [1] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [2] = "The correct answer is SF";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [1] = "The correct answer is SF";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the total flight time for the object.";
				} else {
					stageQuestion = "Enter the total flight time for the object.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[5] = true;
				break;
				//choice of equations for y
			case 12:  //jump here
				if (studentData.getManipulatesEquations() > 45){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 15);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else{
					stageQuestion = "Which set of equations would you like to use.";
					stageType = CHOICE;
					stageQuestion = "Which set of equations would you like to use.";
					numberOfAnswers = 2;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "y = 1/2*a*t^2", 13);
					answer [1] = new Answers (true, "Vfy^2 = Viy^2 + 2*a*y and Vfy = Viy + a*t", 14);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint [0] = "Sorry no hints are available.";
				}
				
				break;
				//solving equation for y
			case 13:
				//If answer 0 for case 8 was chosen go here, why I think we need a stage tree.
				stageType = MULTI_CHOICE;
				stageQuestion = "What is the correct equation for denoting the value we need to solve for.";
				numberOfAnswers = 3;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "t = sqrt(2*y / a)", 15);
				answer [1] = new Answers (false, "y = 1/2 * a*t^2", 13);
				answer [2] = new Answers (false, "a = 2y / t^2", 13);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Ask yourself what are you trying to solve for.";
				hint [1] = "If you know what you are trying to solve for, manipulate the equation so that you have only that value on one side.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[1] = true;
				break;
				//solving equation for y
			case 14:
				//If answe+ase 8 was chose go here, why I think we need a stage tree.
				stageType = MULTI_CHOICE;
				stageQuestion = "What are the correct equations for denoting the value we need to solve for.";
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "Vfy = sqrt(Viy^2 + 2*a*y) and t = (Vfy - Viy) / a", 15);
				answer [1] = new Answers (false, "y = (Vfy^2 - Viy^2) / 2a and t = (Vfy - Viy) / a", 14);
				answer [2] = new Answers (false, "Vfy = sqrt(Viy^2 + 2*a*y) and a = (Vfy -Viy) / t", 14);
				answer [3] = new Answers (false, "y = (Vfy^2 - Viy^2) / 2a and a = (Vfy -Viy) / t", 14);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Ask yourself what are you trying to solve for.";
				hint [1] = "If you know what you are trying to solve for, manipulate the equation so that you have only that value on one side.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[1] = true;
				break;
				//solve for time
			case 15:
				stageType = FILL_IN;
				stageQuestion = "Enter the value of t (time).";
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getTime ().ToString ("#.00"), 16);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Check your values and make sure you entered everything correctly.";
				hint [1] = "Make sure you did not round too much.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[5] = true;
				break;
				//question about acceleration along x
			case 16:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 2;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "No.", 17);
				answer [1] = new Answers (false, "Yes.", 16);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Negating wind resistance since we are in space, what would cause the shot to slow down in the x direction?";
				hint [1] = "An object in motion tends to stay in motion unless acted upon...";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				if (studentData.getUnderstandsXacceleration() == 50 || studentData.getUnderstandsXvelocity() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 17);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Does the shot slow down at all along the x axis?";
				}
				effectsStudentModel[3] = true;
				effectsStudentModel[4] = true;
				break;
				//solving equation for x
			case 17:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 3;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "1/2*a*t^2", 18);
				answer [1] = new Answers (false, "x*t", 17);
				answer [2] = new Answers (false, "Vix", 17);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "What happens if you multiply anything by 0?";
				hint [1] = "Since there is no change to the velocity the acceleration must be 0.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				if (studentData.getUnderstandsXacceleration() == 50 || studentData.getManipulatesEquations() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 18);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Since the ball does not slow down along the x axis what part of this equation is not needed: Vix = x*t - 1/2*a*t^2";
				}
				effectsStudentModel[1] = true;
				effectsStudentModel[3] = true;
				break;
				//solving equation for x
			case 18:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "x = Vix / t", 19);
				answer [1] = new Answers (false, "Vix = x*t - 1/2*a*t^2", 18);
				answer [2] = new Answers (false, "Vix = x*t", 18);
				answer [3] = new Answers (false, "t = Vix / x", 18);
				numberOfHints = 1;
				hint = new string[numberOfHints];
				hint [0] = "Sorry no hints are available.";
				if (studentData.getManipulatesEquations() > 30){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 19);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Since we dont need that part, set up Vix = x*t - 1/2*a*t^2 for our purposes.";
				}
				effectsStudentModel[1] = true;
				break;
				//complete the question
			case 19:
				stageType = FILL_IN;
				stageQuestion = "What is distance between the ships needed for our launch velocity to hit the other ship?";
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer[0] = new Answers(true, problemData.getDistance().ToString("#.00"), -1);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Check your values and make sure you entered everything correctly.";
				hint [1] = "Make sure you did not round too much.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[6] = true;
				break;
			}
			
		}

		//Find x given Vfy, Viy, Vix, ay
		if (type == 4){
			switch (stage) {
				//General givens question.
			case 1:
				if (studentData.getUnderstandsConstants() < 25){
					stageType = MULTI_CHOICE;
					stageQuestion = "The very first thing you should do when you examine a problem is?";
					//answers and which is correct.  Placed randomly. edit, do the random order in the controller.
					numberOfAnswers = 4;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "Identify your givens and what the problem is asking for.", 2);
					answer [1] = new Answers (false, "Fire a warning shot across their bow!", 1); //Dummy answer
					answer [2] = new Answers (false, "Use non-determinism to argue that none of this really matters or it does.", 1); //Dummy answer
					answer [3] = new Answers (false, "Determine the velocity!", 1); //Dummy answer
					//Hints, should be set in sequential order.
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Knowing what info you have and knowing where you are going is really important.";
					hint [1] = "The answer is: " + answer [0].getAnswerText ();
					effectsStudentModel[0] = true;
				} else {
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 2);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				}
				
				break;
				//Select all the givens
			case 2:
				/*if (studentData.getUnderstandsConstants() < 45){
					stageType = SELECT_MULTIPLE;
					stageQuestion = "Select all givens and constants to enter data for.";
					numberOfAnswers = 10;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "Acceleration in the y direction.", 3);
					answer [1] = new Answers (true, "Acceleration in the x direction.", 3);
					answer [2] = new Answers (true, "Initial Velocity in the y direction.", 3);
					answer [3] = new Answers (false, "Enter the height difference between the ships.", 2);
					answer [4] = new Answers (false, "Enter the distance between the two ships.", 2);
					answer [5] = new Answers (false, "The color of the ship.", 2);
					answer [6] = new Answers (true, "Initial Velocity in the x direction.", 3);
					answer [7] = new Answers (true, "Final velocity in the x direction.", 3);
					answer [8] = new Answers (true, "Final velocity in the y direction.", 3);
					answer [9] = new Answers (false, "Total flight time", 2);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint [0] = "Sorry no hints are available.";
					effectsStudentModel[0] = true;
				} else {*/
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 3);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				//}
				break;
				//Acceleration in y
			case 3:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getAccY ().ToString ("#.00"), 4);
				if (studentData.getUnderstandsConstants() < 35 || studentData.getUnderstandsYacceleration() < 40){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "On earth this is a negative value.";
					hint [2] = "This value is often assumed as a constant even if not written. Known as gravity sometimes.";
					hint [3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the acceleration in the y direction.";
				} else {
					stageQuestion = "Enter the acceleration in the y direction. Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[2] = true;
				break;
				//Acceleration in x
			case 4:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, ("0.00")/*problemData.getAccX ().ToString ("#.00")*/, 5);
				if (studentData.getUnderstandsConstants() < 35 || studentData.getUnderstandsXacceleration() < 40){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Does the projectile accelerate or decelerate in the x direction?";
					hint[1] = "This is often not included in the text.";
					hint[2] = "Depending on this value some of of the equations get easier to work with.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is often considered a constant and might not be included in the text.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the acceleration in the x direction.";
				} else {
					stageQuestion = "Enter the acceleration in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[3] = true;
				break;
				//Initial velocity in y
			case 5:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, ("0.00")/*problemData.getYVel ().ToString ("#.00")*/, 6);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "This is often not included in the text.";
					hint[1] = "This is the maximum height of the object.";
					hint[2] = "Remember the shot's initial direction is completely horizontal.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is the maximum height of the object.";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the initial velocity in the y direction.";
				} else {
					stageQuestion = "Enter the initial velocity in the y direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				break;
				//height
			case 6:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "UK", 7);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "Does this have a constant value?  Is it stated in the text?";
					hint [1] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [2] = "Re-examine the main text is this value listed or implied?";
					hint [3] = "The correct answer is UK";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [1] = "The correct answer is UK";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the height differance between the ships.";
				} else {
					stageQuestion = "Enter the height differance between the ships.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				
				effectsStudentModel[0] = true;
				break;
				//distance
			case 7:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "SF", 8);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 3;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text";
					hint [1] = "What is poly asking you to solve for?";
					hint [2] = "The correct answer is SF";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text";
					hint [1] = "The correct answer is SF";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the distance between the two ships.";
				} else {
					stageQuestion = "Enter the distance between the two ships.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
	
				effectsStudentModel[0] = true;
				break;
				//initial velocity in x direction
			case 8:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getXVel().ToString("#.00"), 9);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Read the text carefully.";
					hint[1] = "This should be clearly stated in the text.  Remember that there is no acceleration in x so this could be equal to another value.";
					hint[2] = "This is considered the speed of the object.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text";
					hint [1] = "The correct answer is " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the initial velocity of the projectile in the x direction.";
				} else {
					stageQuestion = "Enter the initial velocity of the projectile in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[4] = true;
				break;
				//final velocity in y
			case 9:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getVelYFin().ToString ("#.00"), 10);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint[0] = "Read the text carefully.";
					hint[1] = "This should be clearly stated in the text.";
					hint[2] = "This would be the speed the shot is going when it passes what would be the \"ground\" level.";
					hint[3] = "The correct answer is: " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Re-examine the main text is this value listed or implied?";
					hint [1] = "The correct answer is: " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the final velocity of the projectile in the y direction.";
				} else {
					stageQuestion = "Enter the final velocity of the projectile in the y direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				
				effectsStudentModel[0] = true;
				break;
				//final velocity in x
			case 10:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getXVel().ToString("#.00"), 11);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 4;
					hint = new string[numberOfHints];
					hint [0] = "This is a bit of a trick question.  What do we know about initial velocities and final?";
					hint [1] = "Is there a force acting upon the x velocity?  If not it should be the same as the initial.";
					hint [2] = "If we know the initial velocity then...";
					hint [3] = "The correct answer is " + answer[0].getAnswerText();
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "This is a bit of a trick question.  What do we know about initial velocities and final?";
					hint [1] = "The correct answer is " + answer[0].getAnswerText();
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the final velocity of the projectile in the x direction.";
				} else {
					stageQuestion = "Enter the final velocity of the projectile in the x direction.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				effectsStudentModel[0] = true;
				effectsStudentModel[4] = true;
				break;
				//time
			case 11:
				stageType = FILL_IN;
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "SF", 12);
				if (studentData.getUnderstandsConstants() < 35){
					numberOfHints = 3;
					hint = new string[numberOfHints];
					hint [0] = "Does this have a constant value?  Is it stated in the text?  Is this something you could be solving for?";
					hint [1] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [2] = "The correct answer is SF";
				} else {
					numberOfHints = 2;
					hint = new string[numberOfHints];
					hint [0] = "Some problems might not have something declared.  This could be an unknown or what you are trying to solve.";
					hint [1] = "The correct answer is SF";
				}
				if (studentData.getUnderstandsConstants() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 12);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else if (studentData.getUnderstandsConstants() > 35){
					stageQuestion = "Enter the total flight time for the object.";
				} else {
					stageQuestion = "Enter the total flight time for the object.  Enter SF if this is what you are solving for, enter UK if unknown.";
				}
				
				effectsStudentModel[0] = true;
				effectsStudentModel[5] = true;
				break;
				//choice of equations for y
			case 12:  //jump here
				if (studentData.getManipulatesEquations() > 45){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 15);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else{
					stageQuestion = "Which set of equations would you like to use.";
					stageType = CHOICE;
					stageQuestion = "Which set of equations would you like to use.";
					numberOfAnswers = 2;
					answer = new Answers[numberOfAnswers];
					answer [0] = new Answers (true, "Vfy = Viy + a*t", 13);
					answer [1] = new Answers (true, "Vfy^2 = Viy^2 + 2*a*y and y = 1/2 * a * t^2", 14);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint [0] = "Sorry no hints are available.";
				}
				
				break;
				//solving equation for y
			case 13:
				//If answer 0 for case 8 was chosen go here, why I think we need a stage tree.
				stageType = MULTI_CHOICE;
				stageQuestion = "What is the correct equation for denoting the value we need to solve for.";
				numberOfAnswers = 3;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "t = (Vfy - Viy) / a", 15);
				answer [1] = new Answers (false, "Viy = Vfy - a*t", 13);
				answer [2] = new Answers (false, "a = (Vfy - Viy) / t", 13);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Ask yourself what are you trying to solve for.";
				hint [1] = "If you know what you are trying to solve for, manipulate the equation so that you have only that value on one side.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[1] = true;
				break;
				//solving equation for y
			case 14:
				//If answe+ase 8 was chose go here, why I think we need a stage tree.
				stageType = MULTI_CHOICE;
				stageQuestion = "What are the correct equations for denoting the value we need to solve for.";
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "y = (Vfy^2 - Viy^2) / 2a and t = sqrt(2y / a)", 15);
				answer [1] = new Answers (false, "y = (Vfy^2 - Viy^2) / 2a and a = (Vfy - Viy) / t", 14);
				answer [2] = new Answers (false, "Vfy = sqrt(Viy^2 + 2*a*y) and t = (Vfy -Viy) / a", 14);
				answer [3] = new Answers (false, "Vfy = sqrt(Viy^2 + 2*a*y) and a = (Vfy -Viy) / t", 14);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Ask yourself what are you trying to solve for.";
				hint [1] = "If you know what you are trying to solve for, manipulate the equation so that you have only that value on one side.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[1] = true;
				break;
				//solve for time
			case 15:
				stageType = FILL_IN;
				stageQuestion = "Enter the value of t (time).";
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, problemData.getTime ().ToString ("#.00"), 16);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Check your values and make sure you entered everything correctly.";
				hint [1] = "Make sure you did not round too much.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[5] = true;
				break;
				//question about acceleration along x
			case 16:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 2;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "No.", 17);
				answer [1] = new Answers (false, "Yes.", 16);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Negating wind resistance since we are in space, what would cause the shot to slow down in the x direction?";
				hint [1] = "An object in motion tends to stay in motion unless acted upon...";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				if (studentData.getUnderstandsXacceleration() == 50 || studentData.getUnderstandsXvelocity() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 17);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Does the shot slow down at all along the x axis?";
				}
				effectsStudentModel[3] = true;
				effectsStudentModel[4] = true;
				break;
				//solving equation for x
			case 17:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 3;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "1/2*a*t^2", 18);
				answer [1] = new Answers (false, "x*t", 17);
				answer [2] = new Answers (false, "Vix", 17);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "What happens if you multiply anything by 0?";
				hint [1] = "Since there is no change to the velocity the acceleration must be 0.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				if (studentData.getUnderstandsXacceleration() == 50 || studentData.getManipulatesEquations() == 50){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 18);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Since the ball does not slow down along the x axis what part of this equation is not needed: Vix = x*t - 1/2*a*t^2";
				}
				effectsStudentModel[1] = true;
				effectsStudentModel[3] = true;
				break;
				//solving equation for x
			case 18:
				stageType = MULTI_CHOICE;
				numberOfAnswers = 4;
				answer = new Answers[numberOfAnswers];
				answer [0] = new Answers (true, "x = Vix / t", 19);
				answer [1] = new Answers (false, "Vix = x*t - 1/2*a*t^2", 18);
				answer [2] = new Answers (false, "Vix = x*t", 18);
				answer [3] = new Answers (false, "t = Vix / x", 18);
				numberOfHints = 1;
				hint = new string[numberOfHints];
				hint [0] = "Sorry no hints are available.";
				if (studentData.getManipulatesEquations() > 30){
					stageType = SKIP;
					stageQuestion = "";
					numberOfAnswers = 1;
					answer = new Answers[numberOfAnswers];
					answer[0] = new Answers(true, "Just a skip", 19);
					numberOfHints = 1;
					hint = new string[numberOfHints];
					hint[0] = "";
				} else {
					stageQuestion = "Since we dont need that part, set up Vix = x*t - 1/2*a*t^2 for our purposes.";
				}
				effectsStudentModel[1] = true;
				break;
				//complete the question
			case 19:
				stageType = FILL_IN;
				stageQuestion = "What is distance between the ships needed for our launch velocity to hit the other ship?";
				numberOfAnswers = 1;
				answer = new Answers[numberOfAnswers];
				answer[0] = new Answers(true, problemData.getDistance().ToString("#.00"), -1);
				numberOfHints = 3;
				hint = new string[numberOfHints];
				hint [0] = "Check your values and make sure you entered everything correctly.";
				hint [1] = "Make sure you did not round too much.";
				hint [2] = "The answer is " + answer[0].getAnswerText();
				effectsStudentModel[6] = true;
				break;
			}
			
		}

	}

	public Answers getAnswer(int idx){
		return answer [idx];
	}
	public string getHint(int idx){
		return hint [idx];
	}
	public string getStageQuestion(){
		return stageQuestion;
		}
	public int getStageType(){
		return stageType;
		}
	public int getNumAnswers(){
		return numberOfAnswers;
		}
	public int getNumHints(){
		return numberOfHints;
	}
	public bool[] getEffectsStudentModel() {
		return effectsStudentModel;
	}
}


