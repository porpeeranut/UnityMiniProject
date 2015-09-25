using UnityEngine;
using System.Collections;

public class BossPower : MonoBehaviour {
	float health;
	float maxHealth;
	bool isDead;
	void Start () {
		maxHealth = 100.0f;
		health = 100.0f;
		isDead = false;
	}
	void Update () {
		
		Debug.Log("Health: " + health); 
	}
	public void GetDamage(float damage){
		health -= damage;
		
		if(health <= 30)
			GetComponent<MeshRenderer>().material.color = Color.red;
		
		if(health <= 0 && !isDead){
			Die();
			
			//Application.LoadLevel(Application.loadedLevel);
		}
	}
	public void AddHealth(float boost){
		health += boost;
		if(health >= maxHealth){
			health = maxHealth;		
			//GetComponent<MeshRenderer>().material.color = Color.white;		
		}
	}
	void Die(){
		Destroy(gameObject); 
	}
}
