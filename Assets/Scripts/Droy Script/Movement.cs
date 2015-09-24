using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	Transform playerTransform;
	NavMeshAgent enemyAgent;
	private float speed;
	
	
	void Start () {
		
		speed = 3.0f;
		enemyAgent = GetComponent<NavMeshAgent> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	
	void Update () {
		
		
		//transform.LookAt(playerTransform.position);
		enemyAgent.SetDestination (playerTransform.position);

		/*float distance = speed*Time.deltaTime;
		Vector3 source = transform.position;
		Vector3 target = playerTransform.position;
		transform.position = Vector3.MoveTowards(source,target,distance);
		*/
		
		
	}
}
