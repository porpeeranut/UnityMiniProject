using UnityEngine;
using System.Collections;

public class SnowStrom : MonoBehaviour {

	public GameObject snow;
	float range = 1.0f;

	void Start () {
		StartCoroutine("SpawnBall",0.02f);
	}
	IEnumerator SpawnBall(float delayTime){
		while(true){

			float offsetX = Random.Range(-range, range);
			float offsetZ = Random.Range(-range, range);
			Vector3 spawnPosition = new Vector3(transform.position.x+offsetX,transform.position.y,transform.position.z+offsetZ);
			Instantiate(snow,spawnPosition,Quaternion.identity);

			yield return new WaitForSeconds(delayTime);
		}
	}
	void Update () {
	}
}
