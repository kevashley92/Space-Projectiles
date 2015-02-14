using UnityEngine;
using System.Collections;

public class StudentModel{
	public const int MAX_KNOWLEDGE_AMOUNT = 50;
	private int understandsConstants = 0;
	private int manipulatesEquations = 0;
	private int understandsYacceleration = 0;
	private int understandsXacceleration = 0;
	private int understandsXvelocity = 0;
	private int correctlySolvesForT = 0;
	private int correctlySolvesTheEquations = 0;


	private int studentModelTotal = 0;

	//getters
	public int getUnderstandsConstants(){
		return understandsConstants;
	}
	public int getManipulatesEquations(){
		return manipulatesEquations;
	}
	public int getUnderstandsYacceleration(){
		return understandsYacceleration;
	}
	public int getUnderstandsXacceleration(){
		return understandsXacceleration;
	}
	public int getUnderstandsXvelocity(){
		return understandsXvelocity;
	}
	public int getCorrectlySolvesForT(){
		return correctlySolvesForT;
	}
	public int getCorrectlySolvesTheEquations(){
		return correctlySolvesTheEquations;
	}


	//incrimenters
	public void incUnderstandsConstants(int amount){
		if (understandsConstants + amount <= MAX_KNOWLEDGE_AMOUNT) {
						understandsConstants += amount;
				} else {
						understandsConstants = MAX_KNOWLEDGE_AMOUNT;
				}
		genStudentSum ();
	}
	public void incManipulatesEquations(int amount){
		if (manipulatesEquations + amount <= MAX_KNOWLEDGE_AMOUNT) {
			manipulatesEquations += amount;
		} else {
			manipulatesEquations = MAX_KNOWLEDGE_AMOUNT;
		}
		genStudentSum ();
	}
	public void incUnderstandsYacceleration(int amount){
		if (understandsYacceleration + amount <= MAX_KNOWLEDGE_AMOUNT) {
			understandsYacceleration += amount;
		} else {
			understandsYacceleration = MAX_KNOWLEDGE_AMOUNT;
		}
		genStudentSum ();
	}
	public void incUnderstandsXacceleration(int amount){
		if (understandsXacceleration + amount <= MAX_KNOWLEDGE_AMOUNT) {
			understandsXacceleration += amount;
		} else {
			understandsXacceleration = MAX_KNOWLEDGE_AMOUNT;
		}
		genStudentSum ();
	}
	public void incUnderstandsXvelocity(int amount){
		if (understandsXvelocity + amount <= MAX_KNOWLEDGE_AMOUNT) {
			understandsXvelocity += amount;
		} else {
			understandsXvelocity = MAX_KNOWLEDGE_AMOUNT;
		}
		genStudentSum ();
	}
	public void incCorrectlySolvesForT(int amount){
		if (correctlySolvesForT + amount <= MAX_KNOWLEDGE_AMOUNT) {
			correctlySolvesForT += amount;
		} else {
			correctlySolvesForT = MAX_KNOWLEDGE_AMOUNT;
		}
		genStudentSum ();
	}
	public void incCorrectlySolvesTheEquations(int amount){
		if (correctlySolvesTheEquations + amount <= MAX_KNOWLEDGE_AMOUNT) {
			correctlySolvesTheEquations += amount;
		} else {
			correctlySolvesTheEquations = MAX_KNOWLEDGE_AMOUNT;
		}
		genStudentSum ();
	}


	//decrimenters
	public void decUnderstandsConstants(int amount){
		if (understandsConstants - amount >= 0) {
						understandsConstants -= amount;
				} else {
						understandsConstants = 0;
				}
		genStudentSum ();
	}
	public void decManipulatesEquations(int amount){
		if (manipulatesEquations - amount >= 0) {
						manipulatesEquations -= amount;
				} else {
						manipulatesEquations = 0;
				}
		genStudentSum ();
	}
	public void decUnderstandsYacceleration(int amount){
		if (understandsYacceleration - amount >= 0) {
						understandsYacceleration -= amount;
				} else {
						understandsYacceleration = 0;
				}
		genStudentSum ();
	}
	public void decUnderstandsXacceleration(int amount){
		if (understandsXacceleration - amount >= 0) {
						understandsXacceleration -= amount;
				} else {
						understandsXacceleration = 0;
				}
		genStudentSum ();
	}
	public void decUnderstandsXvelocity(int amount){
		if (understandsXvelocity - amount >= 0) {
						understandsXvelocity -= amount;
				} else {
						understandsXvelocity = 0;
				}
		genStudentSum ();
	}
	public void decCorrectlySolvesForT(int amount){
		if (correctlySolvesForT - amount >= 0) {
						correctlySolvesForT -= amount;
				} else {
						correctlySolvesForT = 0;
				}
		genStudentSum ();
	}
	public void decCorrectlySolvesTheEquations(int amount){
		if (correctlySolvesTheEquations - amount >= 0) {
						correctlySolvesTheEquations -= amount;
				} else {
						correctlySolvesTheEquations = 0;
				}
		genStudentSum ();
	}


	private void genStudentSum(){
		studentModelTotal = understandsConstants + manipulatesEquations + understandsYacceleration + understandsXacceleration +
						understandsXvelocity + correctlySolvesForT + correctlySolvesTheEquations;
		}


	public int studentModelSum(){
		return studentModelTotal;
		}
}
