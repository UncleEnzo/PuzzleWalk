using UnityEngine;
using System.Collections;

public class MobileDrag : MonoBehaviour {
	//Public Variables
	public GameObject player1;
	//A modifier which affects the rackets speed
	public float speed;
	//Fraction defined by user that will limit the touch area
	public int frac;
	
	//Private Variables
	private float fracScreenWidth;
	private float widthMinusFrac;
	private Vector2 touchCache;
	private Vector3 player1Pos;
	private Vector3 player2Pos;
	private bool touched = false;
	private int screenHeight;
	private int screenWidth;
	
	// Use this for initialization
	void Start () 
	{
		//Cache called function variables
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		fracScreenWidth = screenWidth / frac;
		widthMinusFrac = screenWidth - fracScreenWidth;
		player1Pos = player1.transform.position;
	}
	
	//FixedUpdate is called once per fixed time step
	void FixedUpdate()
	{
		if (touched)
		{
			//Transform rackets
			player1.transform.position = player1Pos;
			touched = false;
		}
	}
}
