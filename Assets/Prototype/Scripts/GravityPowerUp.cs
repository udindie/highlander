using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityPowerUp : MonoBehaviour {

	public float radius = 2f;
	public LayerMask layerMask;
	public float respawnTime = 30;
	float nextRespawnTime;
	public float resetTime = 3;
	float nextResetTime;
	bool active = true;

	Vector3[] gravities = new Vector3[3]{new Vector3(-9.81f,0,0), new Vector3(9.81f,0,0), new Vector3(0, 9.81f,0)};

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Collider2D collider = Physics2D.OverlapCircle((Vector2)transform.position, radius, layerMask);
		if(active && collider) {
			nextRespawnTime = Time.time + respawnTime;
			nextResetTime = Time.time + resetTime;
			GetComponent<Renderer>().enabled=false;
			active = false;
			ChangeGravity(false);
		}

		if(nextRespawnTime <= 0){
			active = true;
			GetComponent<Renderer>().enabled=true;
		}

		if(nextResetTime <= 0){
			ChangeGravity(true);
		}

		if(nextRespawnTime > 0){
			nextRespawnTime -= Time.deltaTime;
		}

		if(nextResetTime > 0){
			nextResetTime -= Time.deltaTime;
		}

	}

	void ChangeGravity(bool reset){
		if(reset){
			Physics2D.gravity = new Vector3(0, -9.81f, 0);
		} else {
			int vectorIndex = (int)Random.Range(0,gravities.Length);
			Physics2D.gravity = gravities[vectorIndex];
		}
	}

}
