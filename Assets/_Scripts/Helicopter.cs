using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	private bool called = false;
	private Rigidbody rigidBody;
	private bool landed = false;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}

	public bool GetIslanded(){
		return landed;
	}

	public bool GetIsCalled(){
		return called;
	}

	public void OnDispatchHelicopter(){
		if (!called){
			Debug.Log("Helicopter called");
			rigidBody.velocity = new Vector3 (0, 0, 50f);
			called = true;
			Invoke("OnLandHelicopter",60f);
			Invoke("OnDropHelicopter",80f);
			Invoke("OnLandedHelicopter",90f);
		}
	}

	private void OnLandHelicopter(){
		Transform landingArea = GameObject.Find("LandingArea(Clone)").transform;
		float distx = landingArea.position.x - transform.position.x;
		float distz = landingArea.position.z - transform.position.z;
		float timeToDrop = 20f;
		rigidBody.velocity = new Vector3 (distx/timeToDrop, 0, distz/timeToDrop);
		transform.RotateAround (transform.position, Vector3.up, (180f/Mathf.PI)*Mathf.Atan(distx/distz));  
	}

	private void OnDropHelicopter(){
		Transform landingArea = GameObject.Find("LandingArea(Clone)").transform;
		float disty = landingArea.position.y - transform.position.y + 2;
		float timeToDrop = 10f;
		rigidBody.velocity = new Vector3 (0, disty/timeToDrop,0);
	}

	private void OnLandedHelicopter(){
		rigidBody.velocity = new Vector3 (0, 0, 0);
		landed = true;
	}



}
