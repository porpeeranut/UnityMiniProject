using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Needed to use Generic lists

public class SqawnEnemy : MonoBehaviour {

	//public GameObject spawnPoint; 
	public GameObject enemy;
	public GameObject enemy2;
	GameObject Enemy;

	float timer;
	float intervalTime;
	List<Vector3> spawnPosList = new List<Vector3>();
	//Vector3 spawnPosition;
	void Start () {
		spawnPosList.Add(new Vector3 (15.6f, 2.19f, 16.0f));
		spawnPosList.Add(new Vector3 (-21.5f, 2.19f, -19.7f));
		spawnPosList.Add(new Vector3 (6.0f, 17.4f, 17.6f));
		Spawn();
		intervalTime = 1.0f;
		timer = intervalTime;

	}
	void Update () {
		timer = timer - Time.deltaTime;
		if (timer <= 0.0f) {
		Spawn ();
			
			timer = intervalTime;
		}
	}
	void Spawn(){
		//Instantiate(enemy,transform.position,Quaternion.identity);
		//float theta = Random.Range(0.0f,2.0f*Mathf.PI);
		//float r = Random.Range(10.0f,20.0f);
		int idx = Random.Range (0, 3);

		//spawnPosition.Set (0.0f, 0.0f, 0.0f);
		Enemy = Random.value < 0.5 ? enemy : enemy2; 

		Instantiate(Enemy,spawnPosList[idx],Quaternion.identity); 
	}
}
