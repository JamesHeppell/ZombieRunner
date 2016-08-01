using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

	private Light torch;
	private bool isTorchOn = false;

	// Use this for initialization
	void Start () {
		torch = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Torch") ){
			ToggleTorch();
		}

	}

	void ToggleTorch(){
		isTorchOn = !isTorchOn ;
		torch.enabled = isTorchOn;
	}

	public bool GetIsTorchOn(){
		return isTorchOn;
	}

	public void SetTorchStateOff(){
		isTorchOn = false ;
		torch.enabled = isTorchOn;
	}

	public void SetTorchStateOn(){
		isTorchOn = true ;
		torch.enabled = isTorchOn;
	}
}
