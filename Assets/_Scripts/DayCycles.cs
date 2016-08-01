using UnityEngine;
using System.Collections;

public class DayCycles : MonoBehaviour {

	[Tooltip ("Number of minutes per second that pass, try 60")]
	public float timeScale;

	public bool isNightTime = false;

	// Update is called once per frame
	void Update () {
		float angleThisFrame = (Time.deltaTime / 360) * timeScale;
	
		transform.RotateAround (transform.position, Vector3.right, angleThisFrame);

		IsNightTime();
	}

	public void IsNightTime(){
		if ((transform.eulerAngles.x >= 180 && transform.eulerAngles.x <= 360) || transform.eulerAngles.x<=10){
			isNightTime = true;
		}else {
			isNightTime = false;
		}
	}

	public bool GetisNightTime(){
		return isNightTime;
	}
	


}
