using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

	public float timeSinceLastTrigger = 0f;

	public int treeNumber = 0; // starting tree number has to be 1

	private bool heliCalled = false;
	private bool foundClearArea = false;

	// Update is called once per frame
	void Update () {
		timeSinceLastTrigger += Time.deltaTime;

		if (timeSinceLastTrigger > 3f && Time.timeSinceLevelLoad > 20f && !foundClearArea && !heliCalled && treeNumber ==0){
			SendMessageUpwards("OnFindClearAreaThought");
			foundClearArea=true;
		}
		if (timeSinceLastTrigger <= 3f){
			foundClearArea=false;
		}

		if(Input.GetButton ("CallHeli") && !heliCalled && foundClearArea ){
			heliCalled=true;
			SendMessageUpwards("OnFindClearArea");
		}
	}

	void OnTriggerStay(Collider collider){
		if (collider.tag !="Player"){
			timeSinceLastTrigger = 0f;
		}
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Terrain" ){
			treeNumber ++;
			timeSinceLastTrigger = 0f;
		}
	}

	void OnTriggerExit(Collider collider){
		if (collider.tag == "Terrain" ){
			treeNumber --;
		}
	}



}
