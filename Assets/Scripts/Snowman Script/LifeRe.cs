using UnityEngine;
using System.Collections;

public class LifeRe : MonoBehaviour {
	float startTime;
	float lifeTime;
	float timer;
	void Start () {
		lifeTime = 1.2f;
		startTime = Time.time;
	}
	void Update () {
		if(Time.time >= (startTime+lifeTime)){
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider obj){

		if(obj.gameObject.CompareTag("Player")){
			obj.GetComponent<PlayerHealth>().AddHealth(1);
		}
	}
}
