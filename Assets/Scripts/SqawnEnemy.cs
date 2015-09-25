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
		spawnPosList.Add(new Vector3 (4.8f, 6.81f, 6.879f));
		spawnPosList.Add(new Vector3 (-8.6f, 7.43f, -7.05f));
		spawnPosList.Add(new Vector3 (0.4f, 10f, -3.0f));
		Spawn();
		intervalTime = 5.0f;
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
		//Enemy = Random.value < 0.5 ? enemy : enemy2; 
		GameObject enemyTmp = null;
		int randomDroy = Random.Range (0, 10);
		if (randomDroy < 6) {
			enemyTmp = (GameObject)Instantiate(enemy, spawnPosList [idx], Quaternion.identity); 
			enemyTmp.GetComponent<DroyHealth> ().setHealth(1) ;
		} else {
			enemyTmp = (GameObject)Instantiate(enemy2, spawnPosList [idx], Quaternion.identity); 
			enemyTmp.GetComponent<DroyHealth> ().setHealth(5) ;
		
		}
		}
}
