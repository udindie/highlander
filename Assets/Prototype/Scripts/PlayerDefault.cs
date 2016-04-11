using UnityEngine;
using System.Collections;

public class PlayerDefault : MonoBehaviour {

	public float jumpForce = 4f;
	public float moveSpeed = 6;
	public bool play;

	public Rigidbody2D rb;

	void Start() {
	}

	void Update() {
		if( play ) {
			Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			transform.Translate(input * Time.deltaTime * moveSpeed);

			if (Input.GetKeyDown (KeyCode.Space)) {
				rb.AddForce(Vector2.up * jumpForce);
			}


		}
		//
		// int wallDirX = (controller.collisions.left) ? -1 : 1;
		//
		// if(!play){
		// 	input = Vector2.zero;
		// }
		//
		// float targetVelocityX = input.x * moveSpeed;
		// velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		//
		// bool wallSliding = false;
		// if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
		// 	wallSliding = true;
		//
		// 	if (velocity.y < -wallSlideSpeedMax) {
		// 		velocity.y = -wallSlideSpeedMax;
		// 	}
		//
		// 	if (timeToWallUnstick > 0) {
		// 		velocityXSmoothing = 0;
		// 		velocity.x = 0;
		//
		// 		if (input.x != wallDirX && input.x != 0) {
		// 			timeToWallUnstick -= Time.deltaTime;
		// 		}
		// 		else {
		// 			timeToWallUnstick = wallStickTime;
		// 		}
		// 	}
		// 	else {
		// 		timeToWallUnstick = wallStickTime;
		// 	}
		//
		// }
		//
		// if (play && Input.GetKeyDown (KeyCode.Space)) {
		// 	if (wallSliding) {
		// 		if (wallDirX == input.x) {
		// 			velocity.x = -wallDirX * wallJumpClimb.x;
		// 			velocity.y = wallJumpClimb.y;
		// 		}
		// 		else if (input.x == 0) {
		// 			velocity.x = -wallDirX * wallJumpOff.x;
		// 			velocity.y = wallJumpOff.y;
		// 		}
		// 		else {
		// 			velocity.x = -wallDirX * wallLeap.x;
		// 			velocity.y = wallLeap.y;
		// 		}
		// 	}
		// 	if (controller.collisions.below) {
		// 		velocity.y = maxJumpVelocity;
		// 	}
		// }
		// if (play && Input.GetKeyUp (KeyCode.Space)) {
		// 	if (velocity.y > minJumpVelocity) {
		// 		velocity.y = minJumpVelocity;
		// 	}
		// }
		//
		//
		// velocity.y += gravity * Time.deltaTime;
		// controller.Move (velocity * Time.deltaTime, input);
		//
		// if (controller.collisions.above || controller.collisions.below) {
		// 	velocity.y = 0;
		// }

	}
}
