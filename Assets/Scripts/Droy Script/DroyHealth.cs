using UnityEngine;
using System.Collections;

public class DroyHealth : MonoBehaviour {

	int health;
	int maxHealth;
	bool isDead;
	public GameObject healthCoin;
	public GameObject DamageCoin; 
	public GameObject BulletCoin; 
	Vector3 spawnPosition; 
	GameObject coin;
	void Start () {
		//maxHealth = 8;
		//health = 10;
		isDead = false;

	}
	void Update () {

		//Debug.Log("Health: " + health); 
	}
	public void Damage(int damage){
	//	Debug.Log (health);
		health -= damage;
		//Debug.Log (health);
			//GetComponent<MeshRenderer>().material.color = Color.red;

		if(health <= 0 && !isDead){
			Die();
			Energy();
			//Application.LoadLevel(Application.loadedLevel);
		}
	}
	/*public void AddHealth(int boost){
		health += boost;
		if(health >= maxHealth){
			health = maxHealth;		
			//GetComponent<MeshRenderer>().material.color = Color.white;		
		}
	}*/
	void Die(){
		Destroy(gameObject); 
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
	public void setHealth(int droyHealth){

		health = droyHealth;

	}

}
