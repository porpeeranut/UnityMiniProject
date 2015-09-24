using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	int health;
	public GameObject healthCoin;
	public GameObject DamageCoin; 
	public GameObject BulletCoin; 
	Vector3 spawnPosition; 
	GameObject coin;
	// Use this for initialization
	void Start () {
		health = 5;

	}

	
	public void Damage(int damage){

		health -= damage;
		Debug.Log (health);
		if (health <= 0) {
			Die();
			Energy();
		}
		
	}
	void Die(){
		Destroy (gameObject);
		}
	
	// Update is called once per frame
	void Update () {

	}

	void Energy(){
		int rItem = Random.Range (0, 10);
		if (rItem < 4) {
		int rType = Random.Range (0, 10);
		if (rType < 4) {
			coin = healthCoin; 
		} else if (rType > 7) {
			coin = DamageCoin;
		} else {
			coin = BulletCoin;
	}
			Instantiate(coin,transform.position,Quaternion.identity);
		}
}
}