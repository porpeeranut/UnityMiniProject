using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {


    //public Transform player;
	NavMeshAgent enemyAgent;
	Transform player;
	//private float speed;


	void Start () {
		enemyAgent = GetComponent<NavMeshAgent> ();
	  // speed = 3.0f;
		player = GameObject.FindGameObjectWithTag("Player").transform;

	}
	

	void Update () {

		if (player != null) {
			transform.LookAt (player.position);// หันหน้าไปทางเพลเยอ
			enemyAgent.SetDestination(player.position);

			/* ศัตรูโง่ๆ
		float distance = speed*Time.deltaTime;
		Vector3 source = transform.position;// ตำแหน่งของศัตรู
		Vector3 target = playerTransform.position;	// postion of player
		transform.position = Vector3.MoveTowards(source,target,distance); // new postion of enemy  ศัตรูsourceวิ่งไปหาเพลเยอtargetจากด้วยระยะทาง distance
		*/
		}
	}

	void OnCollisionEnter(Collision obj){
		
		if (obj.gameObject.CompareTag ("Player")) {//if(obj.gameObject.GetComponent<EnemyHealth>()){
			//			Debug.Log (attack);
			obj.gameObject.GetComponent<PlayerHealth> ().Damage(100);
			
		}
	}
}
