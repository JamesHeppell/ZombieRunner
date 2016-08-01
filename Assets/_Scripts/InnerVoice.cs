using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InnerVoice : MonoBehaviour {

	public AudioClip whatHappened;
	public AudioClip goodLandingArea;
	public AudioClip itsGettingDark;

	private Text playerMessage;
	private bool torchMessageSent = false;
	private AudioSource audioSource;
	private DayCycles daycycle;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = whatHappened;
		audioSource.Play();

		playerMessage = GameObject.Find("PlayerMessage").GetComponent<Text>();

		daycycle = GameObject.FindObjectOfType<DayCycles>();
	}

	void OnFindClearAreaThought(){
		print (name + "OnFindClearAreaThought");
		audioSource.clip = goodLandingArea;
		audioSource.Play();

		playerMessage.text = "Press h to call your helicopter";
		playerMessage.enabled = true;
		Invoke("OnRemovePlayerMessage",3f);
	}

	void OnRemovePlayerMessage(){
		playerMessage.enabled = false;
	}


	void OnFindClearArea(){
		Invoke("CallHeli", goodLandingArea.length +1f);
	}

	void CallHeli(){
		SendMessageUpwards ("OnMakeInitialHeliCall");
	}

	void Update(){
		if (daycycle.GetisNightTime() && !torchMessageSent){
			playerMessage.text = "Press l to use your light";
			playerMessage.enabled = true;
			torchMessageSent = true;
			Invoke("OnRemovePlayerMessage",3f);

			audioSource.clip = itsGettingDark;
			audioSource.Play();
		}
	}

}
