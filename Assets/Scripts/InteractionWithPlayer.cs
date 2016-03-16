using UnityEngine;
using System.Collections;

//TODO MAKE IT SO THAT WHEN BUMPING INTO A GAMEOBJECT YOU ALREADY TRACED OVER THE LINE STOPS
//TODO Disable when player backpedals over the gameobject. BUT NOT WHEN HE HITS IT WITHOUT BACK PEDALLING!!!	

public class InteractionWithPlayer : MonoBehaviour {
	public ParticleSystem DraggedOver;
	public bool isActive = false;
	private GameObject StartingPuzzlePoint;
	private ClickAndDrag ClickandDragScript;


	void Start () {
		//Finds the starting object and its script
		StartingPuzzlePoint = GameObject.Find("StartingPuzzlePoint");
		ClickandDragScript = StartingPuzzlePoint.GetComponent<ClickAndDrag>();
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