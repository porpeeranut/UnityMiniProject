using UnityEngine;
using System.Collections;

public class DroySp : MonoBehaviour {

	public GameObject yellowBall;
	float intervalTime;
	int count=0;
	void Start () {
		intervalTime = 10.0f;
		StartCoroutine("SpawnBall");
	}
	IEnumerator SpawnBall(){
		while(true){
			Instantiate(yellowBall,transform.position,Quaternion.identity);
			count += 1;
			yield return new WaitForSeconds(intervalTime);
		}
	}
	void Update () {
	}
}
