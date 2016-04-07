using UnityEngine;
using System.Collections;

//TODO Create OnCollisionEnter2D if InteractionWithPlayer.Wincondition array = true, return value NextLevel
//TODO pass Value of NextLevel to ButtonMovementAndMotion Script

[RequireComponent(typeof(CircleCollider2D))]
public class EndPointScript : MonoBehaviour {

	private GameObject PuzzlePointsInLevel;
	private PuzzlePointProperties pointEnabled;
	private LevelManager levelManagerScript;
	
	void Start () {
		PuzzlePointsInLevel = GameObject.Find("PuzzlePointsInLevel");
		pointEnabled = PuzzlePointsInLevel.GetComponentInChildren<PuzzlePointProperties>();
		levelManagerScript = FindObjectOfType<LevelManager>();
	}
	
	//If Player hits this object and particle system on all other puzzlepoints = play then access next level script and load next level
	void OnTriggerEnter2D (Collider2D other) {
		//TODO FOR SOME REASON IT ONLY CHECKS IF THE FIRST CHILD PUZZLEPOINT isACTIVE FIX TO CHECK FOR ALL USE AN ARRAY
		if (pointEnabled.isActive == true) {
			levelManagerScript.LoadNextLevel();
		}
	}
	
}
