using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {
	Rigidbody playerRigidbody; // คุณสมบัติทางฟิสิกส์ของ player
	float speed; // ความเร็วของ player
	Vector3 moveDistance; // ระยะทางที่ player จะเคลื่อนที่
	void Start () {
		speed = 20.0f;
	
		playerRigidbody = GetComponent<Rigidbody>();
	}
	void Update () {
	
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");

			moveDistance.Set (-h,0.0f,-v);

			moveDistance = moveDistance.normalized*speed*Time.deltaTime;

			playerRigidbody.MovePosition(transform.position + moveDistance);

			Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitPoint; 

			if(Physics.Raycast(cameraRay,out hitPoint,30)){ 
			Vector3 distanceToMouse = hitPoint.point - transform.position;

			distanceToMouse.y = 0.0f;

			Quaternion newRotation = Quaternion.LookRotation(distanceToMouse);
			playerRigidbody.MoveRotation(newRotation);
			}
	}
}
