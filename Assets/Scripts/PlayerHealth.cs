using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	int health;

	int maxHealth;
	float healthBarLength;

	public Texture2D bgImage; 
	public Texture2D fgImage;

	void Start () {
		health = 300;
		maxHealth = 300;
		healthBarLength = Screen.width /2;
	}

	public void Damage(int damage){
		health -= damage;
		if(health <= 0){
			Die();
		}
	}

	void Die(){
		Destroy(gameObject);
		Application.LoadLevel("Scene2");
	}

	public void AddHealth(int boost){
		health += boost;
		if(health >= maxHealth){
			Application.LoadLevel("Scene2");
		}
	}

	void Update () {
		//Debug.Log("Health: " + health);
		AddjustCurrentHealth(0);
	}

	void OnGUI () {
		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (0,0, healthBarLength,32));
		
		// Draw the background image
		GUI.Box (new Rect (0,0, healthBarLength,32), bgImage);
		
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, health / maxHealth * healthBarLength, 32));
		
		// Draw the foreground image
		GUI.Box (new Rect (0,0,healthBarLength,32), fgImage);
		
		// End both Groups
		GUI.EndGroup ();
		
		GUI.EndGroup ();
	}

	public void AddjustCurrentHealth(int adj){
		health += adj;
		if(health <0)
			health = 0;
		if(health > maxHealth)
			health = maxHealth;
		if(maxHealth <1)
			maxHealth = 1;
		healthBarLength =(Screen.width /2) * (health / (float)maxHealth);
	}
}
