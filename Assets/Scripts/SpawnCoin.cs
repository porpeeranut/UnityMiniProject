using UnityEngine;
using System.Collections;

public class SpawnCoin : MonoBehaviour {

	// Use this for initialization
	/*public GameObject healthCoin;
	public GameObject DamageCoin; 
	public GameObject BulletCoin; 

	Vector3 spawnPosition; 
	GameObject coin;
	void Start () {
		StartCoroutine("HDCoin",5.0f);
		StartCoroutine("BulletCoins",5.0f);
	}
	IEnumerator HDCoin(float delayTime){
		while(true){

			float theta = Random.Range(0.0f,2.0f*Mathf.PI);
			float r = Random.Range(10.0f,20.0f);
			spawnPosition.Set (transform.position.x+r*Mathf.Cos(theta),transform.position.y,transform.position.z+r*Mathf.Sin(theta));
			coin = Random.value < 0.7 ? healthCoin : DamageCoin; 
			Instantiate(coin,spawnPosition,Quaternion.identity); 
			yield return new WaitForSeconds(delayTime);
		} 
	}
	IEnumerator BulletCoins(float delayTime){
		while(true){
			
			float theta = Random.Range(0.0f,2.0f*Mathf.PI);
			float r = Random.Range(10.0f,20.0f);
			spawnPosition.Set (transform.position.x+r*Mathf.Cos(theta),transform.position.y,transform.position.z+r*Mathf.Sin(theta));
			//coin = Random.value < 0.7 ? healthCoin : DamageCoin; 
			Instantiate(BulletCoin,spawnPosition,Quaternion.identity); 
			yield return new WaitForSeconds(delayTime);
		} 
	}
	void Update () {
	} */
}

