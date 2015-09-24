using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject bullet;
	float initialSpeed = 30.0f;
	float shootRate = 0.04f;
	float timer;
	bool isShooting = false;

	void Start () {
		timer = 0.0f;
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
				GameObject gunBullet = (GameObject)Instantiate(bullet, tmpVec, transform.rotation);
				gunBullet.GetComponent<Rigidbody>().velocity = transform.up * initialSpeed;
				timer = 0.0f;
			}
			yield return new WaitForSeconds(delayTime);
		}
	}
}
