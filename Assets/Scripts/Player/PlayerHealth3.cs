using UnityEngine;
using System.Collections;

public class PlayerHealth3 : MonoBehaviour {
	
	int health;

	// Use this for initialization
	void Start () {
		health = 100000;
	}
	
	public void AddHealth(int boost){
		health += boost;
		
	
		if (health > 5) {
			GetComponent<MeshRenderer> ().material.color = Color.blue;
		}
		Debug.Log (health);
	}
	
	public void Damage(int damage){
		health -= damage;
		if (health < 5) {
			GetComponent<MeshRenderer> ().material.color = Color.red;
		}
		if (health <= 0) {
			Die();
		}
		
	}
	void Die(){
		Destroy (gameObject);
		Application.LoadLevel (Application.loadedLevel);
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (health);
	}
}
