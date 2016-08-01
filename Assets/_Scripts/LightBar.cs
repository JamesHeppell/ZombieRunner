using UnityEngine;
using System.Collections;

public class LightBar : MonoBehaviour {

	public float lightScaleFactor = 10f;

	private Torch torch;
	private float lightHealth;
	private RectTransform lightBar;

	// Use this for initialization
	void Start () {
		torch = GameObject.FindObjectOfType<Torch>();
		lightBar = GetComponent<RectTransform>();
		lightHealth = lightBar.sizeDelta[0];

	}
	
	// Update is called once per frame
	void Update () {
		float lightDecrease = Time.deltaTime * lightScaleFactor;

		if (torch.GetIsTorchOn()){
			//this.enabled = true;
			lightHealth -= lightDecrease * 2f;
		}else {
			//this.enabled = false;
			lightHealth += lightDecrease;
			if (lightHealth>200f){
				lightHealth=200f;
			}

		}

		if (lightHealth <=0){
			torch.SetTorchStateOff();
		}

		UpdateLightHealthBar(lightHealth);

	}

	void UpdateLightHealthBar(float lightHealth){
		lightBar.sizeDelta = new Vector2(lightHealth, lightBar.sizeDelta[1]);
	}

}
