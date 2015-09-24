using UnityEngine;
using System.Collections;

public class BulletDroid : MonoBehaviour {

	float startTime;
	float lifeTime;
	float timer;
	void Start(){

		lifeTime = 1.0f;
		startTime = Time.time;
	}
	void Update () {
		if(Time.time >= (startTime+lifeTime)){
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider obj){
		if (obj.gameObject.CompareTag ("Player")) {
			obj.GetComponent<PlayerHealth> ().Damage(2);
		}
	}
}

