using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	float speed;
	Vector3 moveDistance;

	Transform cameraTransform;
	Transform playerTransform;
	GameObject gunObj;

	private Vector3 mouseOrigin;
	float turnLeftSpeed = 18.0f;
	float turnUpSpeed = 3.0f;
	float centerX = Screen.width / 2;
	float centerY = Screen.height / 2;
	private Vector3 vectorCenter;

	void Start () {
		speed = 4.0f;
		vectorCenter = new Vector3(centerX, centerY);
		cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
		gunObj = GameObject.FindGameObjectWithTag("Gun");
	}

	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		float deg = transform.rotation.eulerAngles.y;// * 180.0f / Mathf.PI;
		float rad = (transform.rotation.eulerAngles.y-90) * Mathf.PI / 180.0f;
//		Debug.Log("ro y:"+deg);
//		Debug.Log("cos :"+Mathf.Cos(rad));
//		Debug.Log("sin :"+Mathf.Sin(rad));
//		Debug.Log("");

		//	6 hours func
		moveDistance.Set(-h*Mathf.Sin(rad)+v*Mathf.Cos(rad), 0.0f, -h*Mathf.Cos(rad)+-v*Mathf.Sin(rad));

		moveDistance = moveDistance*speed*Time.deltaTime; // ds = speed*dt

		transform.position = transform.position + moveDistance;
		//cameraTransform.position = cameraTransform.transform.position + moveDistance;
		//cameraTransform.position = transform.position + new Vector3(0.3f, 1.0f, -2.1f);
		cameraTransform.position = transform.position + transform.up*0.6f - transform.forward*0.4f + transform.right*0.1f;

		if(Input.GetMouseButtonDown(0)) {
			gunObj.GetComponent<Gun>().StartShoot();
		}
		if(Input.GetMouseButtonUp(0)) {
			gunObj.GetComponent<Gun>().StopShoot();
		}
		if (Input.GetKeyDown ("space")) {
			jump();
		}

		//--------------- rotate cam ---------------
		float upDownDeg = cameraTransform.rotation.eulerAngles.x;
		float upDownRad = (cameraTransform.rotation.eulerAngles.x) * Mathf.PI / 180.0f;
		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - vectorCenter);

		// up, down (x axis)
		// looking down
		if (pos.y < -0.005) {
			if (upDownDeg < 45 || upDownDeg > 270) {
				cameraTransform.RotateAround(transform.position, transform.right, -pos.y * turnUpSpeed);
				gunObj.transform.RotateAround(transform.position, transform.right, -pos.y * turnUpSpeed);
			}
		}
		// looking up
		if (pos.y > 0.005) {
			if (upDownDeg < 90 || upDownDeg > 340) {
				cameraTransform.RotateAround(transform.position, transform.right, -pos.y * turnUpSpeed);
				gunObj.transform.RotateAround(transform.position, transform.right, -pos.y * turnUpSpeed);
			}
		}
		//Debug.Log("ro x:"+cameraTransform.rotation.eulerAngles.x);
		
		// left, right (y axis)
		if (pos.x < -0.005 || pos.x > 0.005) {
//			Debug.Log("sin:"+Mathf.Sin(upDownRad));
//			Debug.Log("cos:"+Mathf.Cos(upDownRad));
			//cameraTransform.RotateAround(transform.position, Vector3.forward, -pos.x * turnSpeed * Mathf.Sin(upDownRad));
			//cameraTransform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed * Mathf.Cos(upDownRad));
			cameraTransform.RotateAround(transform.position, Vector3.up, pos.x * turnLeftSpeed);
			transform.RotateAround(transform.position, Vector3.up, pos.x * turnLeftSpeed);
		}
		// x = up, down
		// y = left, right
		//------------------------------------------
	}

	void jump () {
		transform.position = transform.position + Vector3.up*0.2f;
	}
}
