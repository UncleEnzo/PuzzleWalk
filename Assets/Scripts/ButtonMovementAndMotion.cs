using UnityEngine;
using System.Collections;

public class ButtonMovementAndMotion : MonoBehaviour {
	public float leftBoundary, rightBoundary, topBoundary, bottomBoundary;

	private float movementLerp = 0f;
	private GridPointManager currentStep;
	private Transform target;
	
	//TODO if click GO, check for EndPointScript.NextLevel.  If !null then LoadNext then levelManagerScript.LoadNextLevel(); 
	//TODO FIGURE OUT WHY LERP ISN"T FUCKING WORKING OVER TIME
	
	public IEnumerator MoveToPosition (Transform target){
		while (Vector3.Distance (transform.position, target.position) > 0f) {
			movementLerp = movementLerp + Time.deltaTime;
			transform.position = Vector3.Lerp (transform.position, target.position, movementLerp);
			yield return new WaitForEndOfFrame();
		}     
	}
	
	public void OnCollisionEnter2D (Collision2D collider) {
		currentStep = collider.gameObject.GetComponent<GridPointManager>();
		Debug.Log("Collision Occurred");
		if (currentStep = null) {
			print ("No current step");
		}
	}
	
		//gameobject in element 0 = left
		//gameobject in element 1 = down
		//gameobject in element 2 = right
		//gameobject in element 3 = Up
		//if null then do nothing
		//TODO creates a target on the button pressed

	public void MoveLeft () {
		if (transform.position.x >= leftBoundary) {
			target = currentStep.nearbyPoints[0].transform;
			StartCoroutine (MoveToPosition (target));
		}else {
			print("Reached left boundary");
		}
	}
	
	public void MoveDown () {
		if (transform.position.y >= bottomBoundary) {
			target = currentStep.nearbyPoints[1].transform;
			StartCoroutine (MoveToPosition (target));
		} else {
			print("Reached bottom boundary");
		}
	}
	
	public void MoveRight () {
		if (transform.position.x <= rightBoundary) {
			target = currentStep.nearbyPoints[2].transform;
			StartCoroutine (MoveToPosition (target));
		}else {
			print("Reached right boundary");
		}
	}
	
	
	public void MoveUp () {
		if (transform.position.y <= topBoundary) {
			target = currentStep.nearbyPoints[3].transform;
			StartCoroutine (MoveToPosition (target));
		}else {
			print("Reached top boundary");
		}
	}
		
	public void Go () {

	}
}
