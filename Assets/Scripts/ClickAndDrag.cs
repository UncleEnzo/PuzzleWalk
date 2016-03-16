using UnityEngine;
using System.Collections;

//TODO Make it so that trace renderer removes lines then you're back pedaling
//TODO NEED TO GIVE THE GRID BOUNDARIES SO THAT the object cannot GO OUT OF THE ACTUAL GRID

[RequireComponent(typeof(CircleCollider2D))]
public class ClickAndDrag : MonoBehaviour {

	private Vector3 offset;
	public TrailRenderer trail;
	public GameObject StartingLocation;//will have to make this a prefabbed spot on the grid
	public bool MouseReleased = false;
	
	//speed at which playermoves
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
	
	void Start () {
		trail.time = Mathf.Infinity;
	}
	
	void Update () {
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
	
	//TODO Need to fix up so that is snaps to center of the object
	void OnMouseDown() {
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		trail.time = Mathf.Infinity;
		MouseReleased = false;
	}
	
	void OnMouseDrag() {
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
		MouseReleased = false;
	}
	
	//TODO FADE trail renderer WHEN IT IS DESTROYED
	public void OnMouseUp() {
		//IF THIS DOES NOT COLLIDE WITH ENDGAME OBJECT if () {
		trail.time = 0;
		//}
		//IF IT DOES NOT COLLIDE WITH ENGAME OBJECT if() {
		this.gameObject.SetActive(false);
		this.gameObject.transform.position = StartingLocation.transform.position;
		this.gameObject.SetActive(true);
		MouseReleased = true;
		//}
	}
	
	//START OF GRIDMOVE
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