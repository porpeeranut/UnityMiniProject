using UnityEngine;
using System.Collections;

public class powerX : MonoBehaviour {

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

	void OnCollisionEnter(Collision obj){	
		if(obj.gameObject.CompareTag("Player")){
			obj.gameObject.GetComponent<PlayerHealth>().Damage(5);
		}
	}
}
