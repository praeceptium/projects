using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControll : MonoBehaviour
{

	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

	[SerializeField]
	float throwForceInXandY = 1f; // to control throw force in X and Y directions

	[SerializeField]
	float throwForceInZ = 50f; // to control throw force in Z direction

	Rigidbody rb;
	public GameHandler script;

	public GameObject racket;
	public GameObject ball;
	Vector3 offset = new Vector3(0,0,0.03f);

	public AudioSource hitsound;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{

		// if you touch the screen
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && ball.transform.position.x>0 && script.playerLastHit==false)
		{

			// getting touch position and marking time when you touch the screen
			touchTimeStart = Time.time;
			startPos = Input.GetTouch(0).position;

			racket.transform.position = ball.transform.position + offset;
			hitsound.Play();

		}
		
		// if you release your finger
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && ball.transform.position.x > 0 && script.playerLastHit == false)
		{

			// marking time when you release it
			touchTimeFinish = Time.time;

			// calculate swipe time interval 
			timeInterval = touchTimeFinish - touchTimeStart;

			// getting release finger position
			endPos = Input.GetTouch(0).position;

			// calculating swipe direction in 2D space
			direction = startPos - endPos;

			// add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
			rb.isKinematic = false;
			rb.velocity = new Vector3(0, 0, 0);
			rb.AddForce(direction.y * throwForceInXandY, throwForceInZ / timeInterval + 100f, -direction.x * throwForceInXandY);
			script.playerLastHit = true;
			script.aiLastHit = false;
			script.aiBounce = 0;
			script.playerBounce = 0;
		}
	}
}
