using UnityEngine;
using System.Collections;

public class RotateMapPowerUp : MonoBehaviour {

	public float radius = 2f;
	public LayerMask layerMask;
	public float respawnTime = 30;
	bool active = true;
	public Transform mapTransform;
	public float rotationSpeed = 1f;

	float nextRespawnTime = 1f;
	public float angle = 0f;
	public float angleRotation = 90f;
	private Vector3 currentAngle;

	// Use this for initialization
	void Start () {
		currentAngle = mapTransform.eulerAngles;
	}

	// Update is called once per frame
	void Update () {
		Collider2D collider = Physics2D.OverlapCircle((Vector2)transform.position, radius, layerMask);
		if(active && collider) {
			nextRespawnTime = Time.time + respawnTime;
			active = false;
			GetComponent<Renderer>().enabled=false;
			angle += angleRotation;
		}

		if(nextRespawnTime <= 0){
			active = true;
			GetComponent<Renderer>().enabled=true;
		}

		if(nextRespawnTime > 0){
			nextRespawnTime -= Time.deltaTime;
		}

		if(mapTransform.rotation.z < angle){
			Rotate();
		}


	}

	void Rotate(){
		Vector3 targetAngle = new Vector3(0,0,angle);
		currentAngle = new Vector3(
             Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * rotationSpeed),
             Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * rotationSpeed),
             Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * rotationSpeed));

         mapTransform.eulerAngles = currentAngle;
		// Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    // mapTransform.rotation = Quaternion.Lerp(mapTransform.rotation, newRotation, Time.deltaTime * rotationSpeed);
	}

}
