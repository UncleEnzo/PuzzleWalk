using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public bool fadeoutAlpha = false;
	public bool autoloadNextLevel;
	
	private float autoloadNextLevelAfter = 3f;
	
	void Start () {
		if (autoloadNextLevel == false) {
		}
		else{
			Invoke ("LoadNextLevel", autoloadNextLevelAfter);
		}
	}
	
	//Add an Invoke to this
	public void LoadLevel(string name){
		Application.LoadLevel (name);
		fadeoutAlpha = true;
	}
	
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
		fadeoutAlpha = true;
	}
	
	
}

