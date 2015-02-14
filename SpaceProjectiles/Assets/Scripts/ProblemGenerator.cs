using UnityEngine;
using System.Collections;

/*
 * Data object.  Used to generate the info and then retrieve such.
 */
public class ProblemGenerator{
	//Constants used in the code
	private int MIN_START_HEIGHT = 10;
	private int MAX_START_HEIGHT = 100;
	private float ACC_CONST = -9.8f;
	private float MIN_START_VELOCITY = 100.0f;
	private float MAX_START_VELOCITY = 1000.0f;



	//All elements that could be part of the problem.  Some of these might not see real use.
	private float velocityXInit;
	private float velocityYinit;
	private float timeFinal;
	private float accelerationY;
	private float accelerationX;
	private float distance;
	private float heightTarget;
	private float maxHeight;
	private float groundOffsetHeight;
	private float angle;
	private float velocityYFin;

	/*
	 * Call this function to generate new data for a variable height launched object with 
	 * no vertical velocity.
	 */
	public  ProblemGenerator(){
			angle = 0f;
			heightTarget = 0f;
			groundOffsetHeight = Random.Range (MIN_START_HEIGHT, MAX_START_HEIGHT);
			maxHeight = groundOffsetHeight;
			accelerationY = ACC_CONST;
			velocityYinit = 0f;
			timeFinal = Mathf.Sqrt (2 * -groundOffsetHeight / accelerationY);
			velocityXInit = Random.Range (MIN_START_VELOCITY, MAX_START_VELOCITY);
			distance = velocityXInit * timeFinal;
			velocityYFin = accelerationY * timeFinal;
			accelerationX = 0;
	
		}

	//Basic getters for the problem data.
	public float getXVel(){
				return velocityXInit;
		}
	public float getYVel(){
				return velocityYinit;
		}
	public float getTime(){
				return timeFinal;
		}
	public float getAccY(){
				return accelerationY;
		}
	public float getDistance(){
				return distance;
		}
	public float getTargetHeight(){
				return heightTarget;
		}
	public float getMaxHeight(){
				return maxHeight;
		}
	public float getInitHeight(){
				return groundOffsetHeight;
		}
	public float getAngle(){
				return angle;
		}
	public float getVelYFin(){
				return velocityYFin;
		}
	public float getAccX(){
				return accelerationX;
		}

}
