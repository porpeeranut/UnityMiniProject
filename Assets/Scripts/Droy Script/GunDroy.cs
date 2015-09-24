using UnityEngine;
using System.Collections;

public class GunDroy : MonoBehaviour {
	NavMeshAgent enemyAgent;
	public Transform player;
	public GameObject bullet;
	float initialSpeed;
	void Start () {
		enemyAgent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;

		initialSpeed = -20.0f;
		InvokeRepeating("Shooting",1.0f,0.1f);
	}
	void Shooting(){

		if(player != null){
			//enemyAgent.transform.LookAt(player.position);
			Vector3 location = transform.position-player.position;
			
			if(location.magnitude <= 5.0){
				//enemyAgent.Stop();

				//GetComponent<MeshRenderer>().material.color = Color.blue;

			}else if(location.magnitude <= 15.0){

				//GetComponent<MeshRenderer>().material.color = Color.cyan;
				GameObject gunBullet = 	(GameObject)Instantiate(bullet,transform.position,transform.rotation);				
				gunBullet.GetComponent<Rigidbody>().velocity = transform.forward*initialSpeed;

			}else{
				//enemyAgent.SetDestination(player.position);

				//GetComponent<MeshRenderer>().material.color = Color.white;
			}
		}


	}
}
