using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour {
	void OnGUI () {
		GUI.skin.button.fontSize = 30;
		// Make a menu box
		GUI.Box(new Rect(Screen.width/3, Screen.height-(Screen.height-350), Screen.width/3, 210), "");
		// Make the Start Game button. If it is pressed, Application.LoadLevel("MainGame") will be executed
		if(GUI.Button(new Rect((Screen.width/3) + 10, Screen.height-(Screen.height-360), (Screen.width/3)-20, 90), "Start Game")) {
			Application.LoadLevel ("MainGame");
		}
		// Make the quit button. If it is pressed, Application.Quit() will be executed
		if(GUI.Button(new Rect((Screen.width/3) + 10, Screen.height-(Screen.height-460), (Screen.width/3)-20, 90), "Quit")) {
			Application.Quit ();
		}
	}
}
