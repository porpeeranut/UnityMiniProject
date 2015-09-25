using UnityEngine;
using System.Collections;

public class GunPlayer : MonoBehaviour {

	public int type;
	public GameObject bullet; 
	public GameObject bullet2; 
	float initialSpeed = 30.0f;
	float shootRate = 0.04f;
	public float timeLeft;
	float timer;
	bool isShooting = false;

	void Start () {
		timer = 0.0f;
	}

	void Update() {
		if (type == 1 ) {
			// End the level here.
			timeLeft -= Time.deltaTime;
			//print("Time left = " + (int)timeLeft + " seconds");
			if (timeLeft <= 0){
				type = 0;
			}
		}
	}
	
	public void StartShoot(){
		isShooting = true;
		StartCoroutine("Shooting", shootRate);
	}

	public void StopShoot(){
		isShooting = false;
	}

	IEnumerator Shooting(float delayTime){
		while(isShooting){
			timer = timer + Time.deltaTime;
			//Debug.Log("timer:"+delayTime);
			if(timer >= delayTime){

				Vector3 tmpVec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
				tmpVec += transform.up * 0.5f;
				GameObject gunBullet = null;
				if (type == 0) {
					gunBullet = (GameObject)Instantiate(bullet, tmpVec, transform.rotation);
					bullet.GetComponent<Bulletplayer>().attack = 1;
				}
				if (type == 1) {
					gunBullet = (GameObject)Instantiate(bullet2, tmpVec, transform.rotation);
					bullet2.GetComponent<Bulletplayer>().attack = 5;
				}
				gunBullet.GetComponent<Rigidbody>().velocity = transform.up * initialSpeed;
				timer = 0.0f;
			}
			yield return new WaitForSeconds(delayTime);
		}
	}
}
