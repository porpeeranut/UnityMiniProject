using UnityEngine;
using System.Collections;


public class GunPlayer2 : MonoBehaviour {
	public int type;
	public GameObject bullet; 
	public GameObject bullet2; 
	float initialSpeed;
	public float timeLeft;
	//float BulletTime = 10.0f;
	Bulletplayer bullets;
	Bulletplayer bullets2;
	void Start () {
		InvokeRepeating("Shooting",1.0f,0.1f);
		initialSpeed = 10.0f;
		bullets = bullet.GetComponent<Bulletplayer> ();
		bullets2 = bullet2.GetComponent<Bulletplayer> ();
	}

	
	void Update()
	{
		if (type == 1 )
		{
			// End the level here.
			timeLeft -= Time.deltaTime;
			print("Time left = " + (int)timeLeft + " seconds");
			if (timeLeft <= 0){
				type = 0;
				//timeLeft = BulletTime;

			}
		
		}
		else if (type == 0)
		{
			//print("Time left = " + (int)timeLeft + " seconds");


		}
		
	}


	void Shooting(){
		if (type == 0) {
			GameObject gunBullet = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
			gunBullet.GetComponent<Rigidbody> ().velocity = transform.forward * initialSpeed;
			bullets.attack = 1;
		}
		if (type == 1) {
			bullets.attack = 5;
			GameObject gunBullet = (GameObject)Instantiate (bullet2, transform.position, transform.rotation);
			gunBullet.GetComponent<Rigidbody> ().velocity = transform.forward * initialSpeed;
			bullets2.attack = 5;


		
	}


}
}
