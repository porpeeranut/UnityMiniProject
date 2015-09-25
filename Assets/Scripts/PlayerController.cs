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
	float timer;
	float jumpPower = 7.0f;
	bool isJumping = false;

	void Start () {
		speed = 3.0f;
		timer = 0.0f;
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
		//cameraTransform.position = transform.position + transform.up*0.8f - transform.forward*1.5f + transform.right*0.3f;
		cameraTransform.position = transform.position + transform.up*0.5f - transform.forward*1.1f + transform.right*0.3f;
		//cameraTransform.position = transform.position + new Vector3(0.3f, 1.0f, -2.1f);

		if(Input.GetMouseButtonDown(0)) {
			gunObj.GetComponent<GunPlayer>().StartShoot();
		}
		if(Input.GetMouseButtonUp(0)) {
			gunObj.GetComponent<GunPlayer>().StopShoot();
		}
		if (Input.GetKeyDown ("space")) {
			if (!isJumping) {
				isJumping = true;
				GetComponent<Rigidbody>().velocity = transform.up * jumpPower;
			}
		}
		if(isJumping && GetComponent<Rigidbody>().velocity.y == 0) {
			isJumping = false;
		}
		
		//--------------- rotate cam ---------------
		float upDownDeg = cameraTransform.rotation.eulerAngles.x;
		float upDownRad = (cameraTransform.rotation.eulerAngles.x) * Mathf.PI / 180.0f;
		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - vectorCenter);

		// up, down (x axis)
		// looking down
		if (pos.y < -0.005) {
			if (upDownDeg < 35 || upDownDeg > 270) {
				cameraTransform.RotateAround(transform.position, transform.right, -pos.y * turnUpSpeed);
				gunObj.transform.RotateAround(transform.position, transform.right, -pos.y * turnUpSpeed);
			}
		}
		// looking up
		if (pos.y > 0.005) {
			if (upDownDeg < 90 || upDownDeg > 350) {
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

	public void changeColor(int BulletType){
		gunObj.GetComponent<GunPlayer>().type = BulletType;
		if (BulletType == 1) {
			gunObj.GetComponent<GunPlayer> ().timeLeft = 10.0f;
		}
	}
}
