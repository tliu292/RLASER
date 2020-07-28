using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name){
		if (name == "Start"){
			ScoreKeeper.Reset();
		}	
		Debug.Log ("Level load requested for " + name);
		Application.LoadLevel(name);
		
	}	
	
	public void QuitRequest(){
		Debug.Log ("Quit");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
}
