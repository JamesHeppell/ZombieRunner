using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform zombieSpawnPointsParent; // parent of spawn points 
	public GameObject zombie;

	private float spawnZombienumber;
	private	Helicopter helicopter;
	private	Player	player;
	private LevelManager levelManager;
	private Transform[] zombiespawnPoints;
	private int currentZombieNumber = 0;
	private UnityStandardAssets.Characters.ThirdPerson.AICharacterControl zombieController;

	// Use this for initialization
	void Start () {
		helicopter = GameObject.FindObjectOfType<Helicopter>();
		player = GameObject.FindObjectOfType<Player>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		zombiespawnPoints = zombieSpawnPointsParent.GetComponentsInChildren<Transform>();
		spawnZombienumber = PlayerPrefsManager.GetDifficulty() + 1f;

	}
	
	// Update is called once per frame
	void Update () {
		WinCondition();
		LoseCondition();


		if (currentZombieNumber < spawnZombienumber && helicopter.GetIsCalled()){
			SpawnZombie();
			currentZombieNumber ++;
		}



	}

	void WinCondition(){
		if (helicopter.GetIslanded() && player.GetIsInLandingArea()){
			levelManager.LoadLevel("03a Win");
		}
	}

	void LoseCondition(){
		if (player.GetIsTouchedByZombie() ){
			levelManager.LoadLevel("03b Lose");
		}else if (player.GetIsDrowned() ){
			levelManager.LoadLevel("03b Lose");
		}

	}

	void SpawnZombie(){
		int i = Random.Range(1,zombiespawnPoints.Length);
		//transform.position = zombiespawnPoints[i].transform.position;
		Instantiate(zombie,zombiespawnPoints[i].transform.position, Quaternion.identity);

		zombieController = GameObject.FindObjectOfType<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
		zombieController.target = player.transform;
	} 


}
