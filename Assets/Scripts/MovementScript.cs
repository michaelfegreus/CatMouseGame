using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	Rigidbody rb;

	public float moveSpeed;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	

	void FixedUpdate () {
		rb.velocity = transform.forward * moveSpeed + Physics.gravity; // All movement
		Ray moveRay = new Ray (transform.position, transform.forward);

		RaycastHit hit;

		//float distanceToObstacle = 0;

		// Cast a sphere wrapping character controller 10 meters forward
		// to see if it is about to hit anything.
		if (Physics.SphereCast (transform.position, 1f, transform.forward, out hit, 3f)) {
			//distanceToObstacle = hit.distance;
			if (Random.Range (0f, 1f) > 0.5f) { // 50% chance of happening
				gameObject.transform.Rotate (0f, 90f, 0f);
			} else { // also 50% chance of happening
				gameObject.transform.Rotate (0f, -90f, 0f);
			}
		}
	}
}
/*
// Movement.cs script:
FIXED UPDATE:
set rigidbody velocity equal to [current forward direction] * 10f + Physics.gravity
declare a var of type Ray, called "moveRay" that starts from [current position] and goes [current forward direction]
// a spherecast is like a thick raycast... read https://docs.unity3d.com/ScriptReference/Physics.SphereCast.html
if Physics.Spherecast with moveRay of radius 1 for distance 3 is TRUE... (if there is an obstacle in front of us...)
	then randomly turn 90 degrees left or right (turn left or right around Y axis)*/