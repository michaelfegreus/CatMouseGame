using UnityEngine;
using System.Collections;

public class RaycastSphereController : MonoBehaviour {

	public Transform sphere;
	//public Transform spherePrefab;

	// Update is called once per frame
	void Update () {
		// Step 1: Define the "ray." This is the easiest way to get mouse input into a ray cast form.
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		// Step 2: Declare a variable to remember all the "impact" information.
		RaycastHit rayHit = new RaycastHit();

		// OPTIONAL: visualize the raycast in the Scene view
		Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.yellow);

		// Step 3: Actually shoot the raycast now. The float is the distance. (You could type "Infinity")
		if (Physics.Raycast (ray, out rayHit, 1000f)) {
			Debug.Log ("I'm hitting something! There's something underneath the mouse cursor!");

			// Move the sphere to wherever the raycast hit.
			sphere.position = rayHit.point; // RaycastHit.point is the place, in world, where the raycast hit.

			// Instantiate a cop of the sphere when we click.
			if (Input.GetKey(KeyCode.Mouse0)){
				GameObject newClone = (GameObject)Instantiate (sphere, rayHit.point, Quaternion.Euler (0f, 0f, 0f));
				newClone.GetComponent<Renderer>().material.color = Random.ColorHSV();
			}
		}
	}
}
