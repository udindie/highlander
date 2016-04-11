using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	public KeyCode action;
	public float timeSpeedPercentage = 0.5f;
	public float duration = 3f;
	public float cooldown = 5f;
	public bool active = true;

	// Update is called once per frame
	void Update () {
		if(active && Input.GetKeyUp(action)){
			Configuration.Instance.UpdateTimescale(timeSpeedPercentage, transform);
			active = false;
			Invoke("EndPower", duration);
		}
	}

	void EndPower(){
		Configuration.Instance.UpdateTimescale(1f, transform);
		Invoke("ActivatePower", cooldown);
	}

	void ActivatePower(){
		active = true;
	}
}
