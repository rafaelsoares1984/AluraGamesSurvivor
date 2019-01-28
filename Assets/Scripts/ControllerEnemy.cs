using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemy : MonoBehaviour, ITakeDamage {

	[Header("Player Reference")]
	public GameObject player;
	private Vector3 direction;
	private float distance;
	private Quaternion rotation;
	private int randoZombie;
	private ControllerPlayer controllerPlayer;
	private Animator animatorEnemy;
	private Rigidbody rigidbodyEnemy;
	private MovementChar myMovement;
	private AnimationChar myAnimationChar;
	private StatusChar status;
	private AudioClip songDie; 
	private Vector3 positionRandom;
	private float countRandon;
	private float timeNextPosition = 4;
	private float percenteGeneratekitMedicine = 0.1f;
	public GameObject kitMedicine;
	private ControllerInterface scriptInterface;
	[HideInInspector]
	public GenerateZombie myGenerator;

	
	// Use this for initialization
	void Start () {
		player= GameObject.FindWithTag(Tags.player);
		SwitchZombies();
		controllerPlayer = player.GetComponent<ControllerPlayer>();
		animatorEnemy = GetComponent<Animator>();
		rigidbodyEnemy =  GetComponent<Rigidbody>();
		myMovement = GetComponent<MovementChar>();
		myAnimationChar = GetComponent<AnimationChar>();
		status =  GetComponent<StatusChar>();
		scriptInterface = GameObject.FindObjectOfType(typeof(ControllerInterface)) as ControllerInterface;
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	void FixedUpdate(){
		direction = player.transform.position - transform.position ;
		myMovement.RotationChar(direction);
	//	myAnimationChar.MoveAnimator(direction.magnitude);
		distance = Vector3.Distance(transform.position,player.transform.position);
		if (distance >15){
			Patrol();
		}else if (distance >2.5){
			
			myAnimationChar.Attack(false);
			myMovement.Movement(direction,status.velocity);
		}else{
			
			myAnimationChar.Attack(true);
			controllerPlayer.textGameOver.SetActive(false);
		}
	}
	void Patrol(){
		countRandon -= Time.deltaTime;
		if(countRandon <=0){
			positionRandom = RandonPosition();
			countRandon += timeNextPosition + Random.Range(-1f,1f);
		}
		bool isPositionRandon = Vector3.Distance(transform.position,positionRandom) <= 0.05;
		if (!isPositionRandon){
			direction = positionRandom - transform.position;
			myMovement.Movement(direction,status.velocity);
		}

	}
	
	Vector3 RandonPosition(){
		Vector3 position = Random.insideUnitSphere * 10;
		position += transform.position;
		position.y = transform.position.y;
		return position;
	}
	
	void AttackPlayer(){
		int damage = Random.Range(20, 30);
    		controllerPlayer.GetComponent<ControllerPlayer>().TakeDamage(damage);
		
	}

	public void TakeDamage(int damage){
		status.life -=damage;
		if (status.life <=0){
			Die();
		}
	}
	
	public void Die(){
		Destroy(gameObject,2);
		myAnimationChar.Die();
		this.enabled = false;
		myMovement.Die();
	    ControllerAudio.instance.PlayOneShot(songDie);
		verifyKitMedicine(percenteGeneratekitMedicine);
		scriptInterface.UpdateQtdZombieDie();
		myGenerator.DecreaseZombieLife();
	}
	
	void verifyKitMedicine(float percentGenerate){
		if (Random.value <= percentGenerate){
			Instantiate(kitMedicine, transform.position , Quaternion.identity);
		}
	}


	void SwitchZombies(){
		randoZombie = Random.Range(1,transform.childCount);
		transform.GetChild(randoZombie).gameObject.SetActive(true);
	}
}
