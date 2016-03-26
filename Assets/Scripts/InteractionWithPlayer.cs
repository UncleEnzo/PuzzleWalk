using UnityEngine;
using System.Collections;

//TODO Create Public Boolean for StepInPuzzle - default false.
//TODO Create Private Boolean StepInPuzzleTriggered - default false.
//TODO Create public boolean array Wincondition default for all objects in array is false
//TODO On start, populate boolean array WinCondition with all objects that have StepInPuzzle = true
//TODO Create OnCollision2D enable boolean array WinCondition set This object boolean to true 


//TODO MAKE IT SO THAT WHEN BUMPING INTO A GAMEOBJECT YOU ALREADY TRACED OVER THE LINE STOPS
//TODO Disable when player backpedals over the gameobject. BUT NOT WHEN HE HITS IT WITHOUT BACK PEDALLING!!!	

public class InteractionWithPlayer : MonoBehaviour {
	public ParticleSystem DraggedOver;
	public bool isActive = false;
	private GameObject Player;
	private ClickAndDrag ClickandDragScript;


	void Start () {
		//Finds the starting object and its script
		Player = GameObject.Find("Player");
		ClickandDragScript = Player.GetComponent<ClickAndDrag>();
		isActive = false;
	}
	
	void Update () {
		//looks for if the mouse has been released, and if so disables particle emitters on objects
		if (ClickandDragScript.MouseReleased == true) {
			DisableEmitterOnMouseRelease ();
			isActive = false;
		}
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		PlayerWalkedOver ();
		isActive = true;
	}
	
	void PlayerWalkedOver () {
		DraggedOver.Play();
		}
	
	void PlayerBackTracked () {
		DraggedOver.Stop();
	}
	
	void DisableEmitterOnMouseRelease () {
		DraggedOver.Stop();
	}
}