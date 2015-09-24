using UnityEngine;
using System.Collections;

public class EyeWinks : MonoBehaviour {
	NavMeshAgent enemyAgent;
	public Transform player;
	void Start () {
		enemyAgent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	void Update () {
		if(player != null){
			enemyAgent.transform.LookAt(player.position);
			Vector3 location = transform.position-player.position;
			
			if(location.magnitude <= 5.0){
				//enemyAgent.Stop();
				enemyAgent.speed = 20.0f;
				GetComponent<MeshRenderer>().material.color = Color.red;
			}else if(location.magnitude <= 15.0){
				enemyAgent.speed = 1.0f;
				GetComponent<MeshRenderer>().material.color = Color.yellow;
			}else{
				//enemyAgent.SetDestination(player.position);
				enemyAgent.speed = 10.0f;
				GetComponent<MeshRenderer>().material.color = Color.green;
			}
		}
	}
}
