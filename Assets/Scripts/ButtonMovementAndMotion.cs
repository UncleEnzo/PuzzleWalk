using UnityEngine;
using System.Collections;

public class ButtonMovementAndMotion : MonoBehaviour {
	private float movementLerp = 0f;
	public Transform target;
	public float leftBoundary, rightBoundary, topBoundary, bottomBoundary;

	//TODO if click GO, check for EndPointScript.NextLevel.  If !null then LoadNext then levelManagerScript.LoadNextLevel(); 
	//TODO FIGURE OUT WHY LERP ISN"T FUCKING WORKING OVER TIME
	
	public IEnumerator MoveToPosition (Transform target){
		while (Vector3.Distance (transform.position, target.position) > 0.0f) {
			transform.position = Vector3.Lerp (transform.position, target.position, movementLerp * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}     
		yield return gameObject.transform.position;
	}

	public void MoveRight () {
		if (transform.position.x <= rightBoundary) {
			Vector3 moveRight = new Vector3 (1, 0, 0); 
			target.transform.position += moveRight;
			StartCoroutine (MoveToPosition (target));
		}else {
			print("Reached right boundary");
		}
	}
	
	public void MoveLeft () {
		if (transform.position.x >= leftBoundary) {
			Vector3 moveLeft = new Vector3 (-1, 0, 0); 
			target.transform.position += moveLeft;
			StartCoroutine (MoveToPosition (target));
		}else {
			print("Reached left boundary");
		}
	}
	
	public void MoveUp () {
		if (transform.position.y <= topBoundary) {
			Vector3 moveUp = new Vector3 (0, 1, 0); 
			target.transform.position += moveUp;
			StartCoroutine (MoveToPosition (target));
		}else {
			print("Reached top boundary");
		}
	}
	
	public void MoveDown () {
		if (transform.position.y >= bottomBoundary) {
			Vector3 moveDown = new Vector3 (0, -1, 0); 
			target.transform.position += moveDown;
			StartCoroutine (MoveToPosition (target));
		} else {
			print("Reached bottom boundary");
		}
	}
	
	public void Go () {

	}
}
