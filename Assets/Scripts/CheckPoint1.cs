using UnityEngine;
using System.Collections;

public class CheckPoint1 : MonoBehaviour {

	GameObject lightZone1;

	void Start () {
		lightZone1 = GameObject.FindGameObjectWithTag("LightZone1");
	}

	void OnTriggerEnter (Collider obj){
		if(obj.gameObject.CompareTag("Player")){
			lightZone1.SetActive (false);
		}
	}
}
