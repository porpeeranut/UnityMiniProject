using UnityEngine;
using System.Collections;

public class SpwanBoss : MonoBehaviour {

	public GameObject boss;
	bool isBossSpawned = false;

	public void spawnBoss(){
		if (!isBossSpawned) {
			GameObject bossTmp = (GameObject)Instantiate(boss, transform.position, Quaternion.identity); 
			bossTmp.GetComponent<DroyHealth> ().setHealth(50) ;
			bossTmp.GetComponent<DroyHealth> ().setIsBoss();
			isBossSpawned = true;
		}
	}
}
