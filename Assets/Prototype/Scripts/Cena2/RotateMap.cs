using UnityEngine;
using System.Collections;

public class RotateMap : MonoBehaviour {

	public KeyCode actionHold;
	public KeyCode actionDirectionUp;
	public KeyCode actionDirectionLeft;
	public KeyCode actionDirectionRight;
	public Transform target;
	public bool stopTime = false;
	public float duration = 2.5f;
	public float cooldown = 5f;
	public bool active = true;
	bool rotate = false;
	public float startAngle;
	public float rotationAngle;
	float lasttime;
	float time;

	// Update is called once per frame
	void Update () {
		if(active && Input.GetKey(actionHold) && HasRotationAngle()){
			lasttime = time;
			time = Time.time;
			active = false;
			rotate = true;
			if(stopTime){
				Configuration.Instance.UpdateTimescale(0f,null);
			}
			Invoke("EndPower", duration);
		}
		if(rotate){
			Rotate();
		}
	}

	bool HasRotationAngle(){
		if(Input.GetKeyDown(actionDirectionLeft)){
			rotationAngle = 90;
			return true;
		}
		if(Input.GetKeyDown(actionDirectionUp)){
			rotationAngle = 180;
			return true;
		}
		if(Input.GetKeyDown(actionDirectionRight)){
			rotationAngle = 270;
			return true;
		}
		return false;

	}

	void EndPower(){
		rotate = false;
		startAngle = (startAngle + rotationAngle) % 360;
		target.rotation= Quaternion.AngleAxis(startAngle, Vector3.forward);
		if(stopTime){
			Configuration.Instance.UpdateTimescale(1f,null);
		}
		Invoke("ActivatePower", cooldown);
	}

	void ActivatePower(){
		active = true;
	}

	void Rotate(){
		lasttime = time;
		time = Time.time;
		float finalAngle = startAngle + rotationAngle;
		float speed = rotationAngle / duration;

		Quaternion newRotation = Quaternion.AngleAxis(finalAngle, Vector3.forward);
	 	target.rotation= Quaternion.Slerp(target.rotation, newRotation, speed * (time - lasttime));
	}
}
