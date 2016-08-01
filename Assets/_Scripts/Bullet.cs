using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float bulletSpeed = 10f;

	private Transform mouseClick;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( new Vector3(Time.deltaTime * bulletSpeed,0,0),Space.World); 
	}



}
