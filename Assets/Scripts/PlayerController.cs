using UnityEngine;

/**
 * This script moves and rotates the player based on keyboard inputs.
 * Uses Input axes. Settings could be check from Project Settings -> Input Manager -> Axes
 * Horizontal Axis(A-D keys and left-right arrow keys) makes player rotate around.
 * Vertical Axis(W-S keys and up-down arrow keys) makes player move forward or backward if Input Manager settings are default values.
 */
public class PlayerController : MonoBehaviour {

	public float movementSpeed = 2f;
	public float rotationSpeed = 50f;

	private Animator animator;
	private Rigidbody rigidBody;

	void Start() {
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		float translation = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

		Quaternion quat = Quaternion.Euler(0f , rotation , 0f);

		rigidBody.MovePosition(transform.position + transform.forward * translation);
		rigidBody.MoveRotation(transform.rotation * quat);

		if(translation == 0) {
			animator.SetBool("isRunning" , false);
		} else {
			animator.SetBool("isRunning" , true);
		}
	}
}
