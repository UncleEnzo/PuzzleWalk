using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {
	private GameObject StartingPuzzlePoint;
	
	// Use this for initialization
	void Start () {
		StartingPuzzlePoint = GameObject.Find("StartingPuzzlePoint");
	}
	
	// Update is called once per frame
	void Update () {
		StartingPuzzlePoint.rigidbody.velocity = Vector3.zero;
	}
}
