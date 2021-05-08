using UnityEngine;

/**
 * This script is to make camera follow the player smoothly while player moving or rotating around.
 * First we have found the vector from camera to player + offset. Then we found the rotation quat from this vector and then used slerp for better animation.
 * We could have use the Transform.LooakAt() however it would be less smooth since it directly calculates to see the given target.
 * Then we moved camera from height upper the player and distance further behind for better looking.
 */
public class CameraFollower : MonoBehaviour {

	public Transform player;
	[Min(1f)]
	public float height;
	public float distance;
	public Vector3 offset;
	[Range(50f , 300f)]
	public float cameraSpeed;
	[Range(50f , 300f)]
	public float rotationSpeed;


	// Update is called once per frame
	void FixedUpdate() {
		Vector3 relativePosition = player.position + offset - transform.position;
		Quaternion rotationQuat = Quaternion.LookRotation(relativePosition);

		// 0.1f multipier is using just to be sure about value will is not too close to 0 or 1.
		transform.rotation = Quaternion.Slerp(transform.rotation , rotationQuat , rotationSpeed * Time.deltaTime * 0.1f);

		Vector3 targetPosition = player.transform.position + player.up * height - player.forward * distance;

		// 0.1f multipier is using just to be sure about value will is not too close to 0 or 1.
		transform.position = Vector3.Lerp(transform.position , targetPosition , Time.deltaTime * cameraSpeed * 0.1f);
	}
}
