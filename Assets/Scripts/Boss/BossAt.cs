using UnityEngine;
using System.Collections;

public class BossAt : MonoBehaviour {
	public GameObject ball;
	
	void Start () {
		StartCoroutine("SpawnBall",1.02f);
	}
	IEnumerator SpawnBall(float delayTime){
		while(true){
			
			float offsetX = Random.Range(-6.0f,6.0f);
			float offsetZ = Random.Range(-3.0f,3.0f);
			Vector3 spawnPosition = new Vector3(transform.position.x+offsetX,transform.position.y,transform.position.z+offsetZ);
			Instantiate(ball,spawnPosition,Quaternion.identity);			
			yield return new WaitForSeconds(delayTime);
		}
	}
	void Update () {
	}
}
