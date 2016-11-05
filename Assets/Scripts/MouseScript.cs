using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {

	public Transform cat;

	void Start () {
	
	}
	
	void FixedUpdate () {
		Vector3 directionToCat = cat.position - transform.position;
		float angle = Vector3.Angle( directionToCat, transform.forward );
		if(angle < 180){
			Ray mouseRay = new Ray (transform.position, directionToCat);
			RaycastHit mouseRayHitInfo;
			if (mouseRay (transform.position, 1f, transform.forward, out mouseRayHitInfo, 100f)) {
		}
	}
}
/*
Mouse.cs script:

declare a public variable, of type Transform, called "cat" (and assign this in the Inspector)

FIXED UPDATE:
declare a var of type Vector3, called "directionToCat", set to a vector that goes from [current position] to [cat's current position]
	// to calculate the euler angle between two directions, google "Unity Vector3.Angle" 
	if the angle between [current forward direction] vs. [directionToCat] is less than 180 degrees, then...
	declare a var of type Ray, called "mouseRay" that starts from [current position] and goes along [directionToCat]
	declare a var of type RaycastHit, called "mouseRayHitInfo"
	if raycast with mouseRay and mouseRayHitInfo for 100 units is TRUE, then... 
	if mouseRayHitInfo.collider.tag is exactly equal to the word "Cat"... (mouse sees cat!)
	add force on rigidbody, along [-directionToCat.normalized * 1000f] (run away!)*/