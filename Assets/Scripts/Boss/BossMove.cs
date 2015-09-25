using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour {

	Transform player;
	NavMeshAgent enemyAgent;
	private float speed;
	
	float startTime;
	float lifeTime;
	float timer;


	void Start () {
		lifeTime = 5.0f;
		startTime = Time.time;

		//speed = 3.0f;
		enemyAgent = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	
	void Update () {
		enemyAgent.speed = 100.0f;
		//enemyAgent.transform.LookAt(player.position);
		enemyAgent.SetDestination (player.position);
		lifeTime = lifeTime - Time.deltaTime;
		if(lifeTime < 2.0f){
			enemyAgent.transform.LookAt(player.position);
			enemyAgent.speed = -100.0f;
			lifeTime = lifeTime - Time.deltaTime;
			if(lifeTime <= 0.0f){
				lifeTime = 5.0f;
			}

		}
		//transform.LookAt(playerTransform.position);
		//	enemyAgent.SetDestination (playerTransform.position);
		
		/*float distance = speed*Time.deltaTime;
		Vector3 source = transform.position;
		Vector3 target = playerTransform.position;
		transform.position = Vector3.MoveTowards(source,target,distance);
		*/
		
		
	}
}
