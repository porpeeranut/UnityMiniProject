using UnityEngine;
using System.Collections;

public class ArmRotate : MonoBehaviour {
	float speed;
	float timer;
	float intervalTime;
	// Use this for initialization
	void Start () {
		speed = 45.0f;

		intervalTime = 2.0f;
		timer = intervalTime;
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer - Time.deltaTime;
	    if(timer <= 0.0f){
			speed = -1 * speed;
			timer = intervalTime;
		}
		transform.Rotate (Vector3.right, -1*speed * Time.deltaTime);
	}
}
