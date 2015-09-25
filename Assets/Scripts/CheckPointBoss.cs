using UnityEngine;
using System.Collections;

public class CheckPointBoss : MonoBehaviour {

	GameObject bossPoint;

	void Start () {
		bossPoint = GameObject.FindGameObjectWithTag("BossSpawnPoint");
	}

	void OnTriggerEnter (Collider obj){
		if(obj.gameObject.CompareTag("Player")){
			bossPoint.GetComponent<SpwanBoss>().spawnBoss();
		}
	}
}
