using UnityEngine;
using System.Collections;

public class ButtonMovementAndMotion : MonoBehaviour {
	public float smoothing = .0001f;
	public Transform target;
	public float leftBoundary, rightBoundary, topBoundary, bottomBoundary;

	//TODO character move using the buttons, X, -X, Y, -Y distance
	//TODO if player transform is at limitX, limit-X, limitY, limit-Y, gray out button
	//TODO if click GO, check for EndPointScript.NextLevel.  If !null then LoadNext then levelManagerScript.LoadNextLevel(); 
	
	public IEnumerator MoveToPosition (Transform target){
		while (Vector3.Distance (transform.position, target.position) > 0f) {
			Vector3.Lerp (transform.position, target.position, smoothing * Time.deltaTime);
			yield return gameObject.transform.position;
		}     
	}

	public void MoveRight () {
		if (transform.position.x <= rightBoundary) {
			Vector3 moveRight = new Vector3 (1, 0, 0); 
			target.transform.position += moveRight;
			//Vector3 target = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z);
			StartCoroutine (MoveToPosition (target));
		}else {
			print("Reached right boundary");
		}
	}
	
	public void MoveLeft () {
		if (transform.position.x >= leftBoundary) {
			Vector3 moveLeft = new Vector3 (-1, 0, 0); 
			target.transform.position += moveLeft;
			//Vector3 target = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z);
			StartCoroutine (MoveToPosition (target));
		}else {
			print("Reached left boundary");
		}
	}
	
	public void MoveUp () {
		if (transform.position.y <= topBoundary) {
			Vector3 moveUp = new Vector3 (0, 1, 0); 
			target.transform.position += moveUp;
			//Vector3 target = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z);
			StartCoroutine (MoveToPosition (target));
		}else {
			print("Reached top boundary");
		}
	}
	
	public void MoveDown () {
		if (transform.position.y >= bottomBoundary) {
			Vector3 moveDown = new Vector3 (0, -1, 0); 
			target.transform.position += moveDown;
			//Vector3 target = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z);
			StartCoroutine (MoveToPosition (target));
		} else {
			print("Reached bottom boundary");
		}
	}
	
	public void Go () {

	}
}
