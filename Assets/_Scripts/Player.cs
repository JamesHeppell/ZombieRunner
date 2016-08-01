using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject landingArea;
	public Transform playerSpawnPoints; // parent of swpan points

	private bool reSpawn = true;
	private Transform[] spawnPoints;
	private bool lastRespawnToggle = false;
	private bool IsInLandingArea = false;
	private bool IsTouchedByZombie = false;
	private bool IsDrowned = false;

	// Use this for initialization
	void Start () {
		spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
	}


	private void ReSpawn(){
		int i = Random.Range(1,spawnPoints.Length);
		transform.position = spawnPoints[i].transform.position;
	} 

	// Update is called once per frame
	void Update () {
		if (lastRespawnToggle != reSpawn){
			ReSpawn();
			reSpawn = false;
		}else {
			lastRespawnToggle = reSpawn;
		}



	}

	void OnFindClearArea(){
		Debug.Log ("Found clear area in player");
		Invoke ("DropFlare", 3f);
	}

	void DropFlare(){
		Instantiate(landingArea, transform.position, transform.rotation);
	}

	public bool GetIsInLandingArea(){
		return IsInLandingArea;
	}

	public bool GetIsTouchedByZombie(){
		return IsTouchedByZombie;
	}

	public bool GetIsDrowned(){
		return IsDrowned;
	}

	void OnTriggerStay (Collider collider){

		if (collider.tag == "LandingArea"){
			IsInLandingArea =true;
			Debug.Log("Player in " + collider);
		} else{
			IsInLandingArea =false;
			Debug.Log("Player is not in " + collider);
		}
	}

	void OnTriggerEnter(Collider collider){
		Debug.Log(collider + " entered Player");
		if (collider.tag == "Zombie"){
			IsTouchedByZombie = true;
		}else if (collider.tag == "Water"){
			IsDrowned = true;
		}
	}
}
