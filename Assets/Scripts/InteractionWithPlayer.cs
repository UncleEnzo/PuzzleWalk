using UnityEngine;
using System.Collections;

public class InteractionWithPlayer : MonoBehaviour {
	public ParticleSystem DraggedOver;
	private GameObject StartingPuzzlePoint;
	private ClickAndDrag ClickandDragScript;

	void Start () {
		StartingPuzzlePoint = GameObject.Find("StartingPuzzlePoint");
		ClickandDragScript = StartingPuzzlePoint.GetComponent<ClickAndDrag>();
		}
	
	void Update () {
		if (ClickandDragScript.MouseReleased == true) {
			Debug.Log(ClickandDragScript.MouseReleased);
			DisableEmitterOnMouseRelease ();
		}
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		PlayerWalkedOver ();
	}
	
	void PlayerWalkedOver () {
		DraggedOver.Play();
		}
	
	//TODO Disable when player backpedals over the gameobject. BUT NOT WHEN HE HITS IT WITHOUT BACK PEDALLING!!!	
	void PlayerBackTracked () {
		DraggedOver.Stop();
	}
	
	void DisableEmitterOnMouseRelease () {
		DraggedOver.Stop();
	}
	
	//TODO MAKE IT SO THAT WHEN BUMPING INTO A GAMEOBJECT YOU ALREADY TRACED OVER THE LINE STOPS
}