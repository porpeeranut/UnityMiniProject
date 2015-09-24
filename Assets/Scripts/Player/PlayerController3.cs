using UnityEngine;
using System.Collections;

public class PlayerController3 : MonoBehaviour {
	public GameObject gun;
	float speed;
	Vector3 moveDistance;

	public Rigidbody playerRigidbody;

	void Start () {

		speed = 10.0f;
		playerRigidbody = GetComponent<Rigidbody>();
	
	}
	
	// Upzzte is called once per frame
	void Update () {

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		moveDistance.Set (h,0.0f,v);
		//Debug.Log (moveDistance);
		moveDistance = moveDistance.normalized*speed*Time.deltaTime; // ds = speed*dt

		playerRigidbody.MovePosition(transform.position + moveDistance);
	
	}
	public void changeColor(int BulletType){
		gun.GetComponent<GunPlayer>().type = BulletType;
		if (BulletType == 1) {
			gun.GetComponent<GunPlayer> ().timeLeft = 10.0f;
		}
	}

}
