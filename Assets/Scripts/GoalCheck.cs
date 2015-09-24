using UnityEngine;
using System.Collections;

public class GoalCheck : MonoBehaviour {


	//void OnCollisionEnter(Collision obj){

	void OnTriggerEnter(Collider obj){

		if(obj.gameObject.CompareTag("Player")){
			Destroy(gameObject);
			Destroy (obj.gameObject);

			Application.LoadLevel("Scene2");
		}
	}


}
