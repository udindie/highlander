using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Configuration : Singleton<Configuration> {
	protected Configuration(){}

	Dictionary<Transform,ObjectConfig> configurations = new Dictionary<Transform, ObjectConfig>();

	public void Register(Transform transform) {
		configurations[transform] = new ObjectConfig();
	}

	public void UpdateTimescale(float value, Transform source) {
		foreach (Transform t in configurations.Keys){
			if(t != source){
				configurations[t].timescale = value;
			}
		}
	}

	public float Timescale(Transform source) {
		return configurations[source].timescale;
	}

	public class ObjectConfig {
		public float timescale;

		public ObjectConfig() {
			timescale = Time.timeScale;
		}
	}
}
