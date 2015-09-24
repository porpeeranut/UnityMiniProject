using UnityEngine;
using System.Collections;

public class EnergyCheck2 : MonoBehaviour {

	float speed;

	void Start(){

		speed = 360.0f;

	}

	void Update(){

		transform.Rotate(0.0f,0.0f,speed*Time.deltaTime);

	}

	void OnTriggerEnter(Collider obj){
		
		if(obj.gameObject.CompareTag("Player")){

			Destroy(gameObject);

			obj.GetComponent<PlayerHealth>().AddHealth(2);
		}
	}
}
