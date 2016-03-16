using System.Collections;
using UnityEngine;

//TODO MELD THE CLICK AND DRAG MECHANICS INTO THIS SCRIPT
class GridMove : MonoBehaviour {
	//speed at which he moves
	private float moveSpeed = 3f;
	//size of each grid square
	private float gridSize = 1f;
	//you can move
	private enum Orientation {
		Horizontal,
		Vertical
	};
	private Orientation gridOrientation = Orientation.Vertical;
	//TODO KEEP THIS DISABLED, FOCUS ON REMOVING
	private bool allowDiagonals = false;
	//TODO UNSURE
	private bool correctDiagonalSpeed = true;
	//TODO REPLACE WITH WITH THE DRAG AND DROP MECHANIC
	private Vector2 input;
	//checks to see if object is moving
	private bool isMoving = false;
	//Starting position of object, filled in in the IEnumerator move function
	private Vector3 startPosition;
	//Ending position of object, filled in in the IEnumerator move function
	private Vector3 endPosition;
	private float t;
	private float factor;
	
	public void Update() {
		if (!isMoving) {
			input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			//TODO SEEMS UNNECESSARY
			if (!allowDiagonals) {
				if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
					input.y = 0;
				} else {
					input.x = 0;
				}
			}
			
			if (input != Vector2.zero) {
				StartCoroutine(move(transform));
			}
		}
	}
	
	public IEnumerator move(Transform transform) {
		isMoving = true;
		//start position == to the variables in the enumerator, horizantle and vertical
		startPosition = transform.position;
		t = 0;
		
		if(gridOrientation == Orientation.Horizontal) {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                          startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
		} else {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                          startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
		}
		
		//TODO SEEMS UNNECCESARY. CONSIDER EDITING OUT LATER
		if(allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
			factor = 0.7071f;
		} else {
			factor = 1f;
		}
		
		while (t < 1f) {
			t += Time.deltaTime * (moveSpeed/gridSize) * factor;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return null;
		}
		
		isMoving = false;
		yield return 0;
	}
}