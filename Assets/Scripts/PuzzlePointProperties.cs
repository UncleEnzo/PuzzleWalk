using UnityEngine;
using System.Collections;

//TODO Create Public Boolean for StepInPuzzle - default false.
//TODO Create Private Boolean StepInPuzzleTriggered - default false.
//TODO Create public boolean array Wincondition default for all objects in array is false
//TODO On start, populate boolean array WinCondition with all objects that have StepInPuzzle = true
//TODO Create OnCollision2D enable boolean array WinCondition set This object boolean to true 

public class PuzzlePointProperties : MonoBehaviour {

	//TODO MAKE IT SO THAT WHEN BUMPING INTO A GAMEOBJECT YOU ALREADY TRACED OVER THE LINE STOPS
	//TODO Disable particle emitter when player backpedals over them.

	public bool isActive = false;
	
	private ParticleSystem particleEmitters;

	// Use this for initialization
	void Start () {
		isActive = false;
		particleEmitters = GetComponent<ParticleSystem>();
	}
		
	void OnTriggerEnter2D (Collider2D other) {
		PlayerWalkedOver ();
		isActive = true;
	}
	
	void PlayerWalkedOver () {
		particleEmitters.Play();
	}
}
