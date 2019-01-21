using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemy : MonoBehaviour, ITakeDamege {

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
	private AudioClip ControllerAudio;
	private Vector3 positionRandom;
	private float countRandon;
	private float timeNextPosition = 4;
	
	
	// Use this for initialization
	void Start () {
		player= GameObject.FindWithTag("Player");
		SwitchZombies();
		controllerPlayer = player.GetComponent<ControllerPlayer>();
		animatorEnemy = GetComponent<Animator>();
		rigidbodyEnemy =  GetComponent<Rigidbody>();
		myMovement = GetComponent<MovementChar>();
		myAnimationChar = GetComponent<AnimationChar>();
		status = GetComponent<StatusChar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	void FixedUpdate(){
		direction = player.transform.position - transform.position ;
		myMovement.RotationChar(direction);
		myAnimationChar.Movement(direction.magnitude)
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
		countRandon -= Time.deltaTima;
		if(countRandon <=0){
			positionRandom = RandonPosition();
			countRandon = timeNextPosition;
		}
		bool isPositionRandon = Vector3.Distance(transform.position,positionRandom) <= 0.05;
		if (!isPositionRandon){
			direction = positionRandom - transform.position;
			myMovement.Movement(direction,status.velocity);
		}

	}
	
	Vector3 RandonPosition(){
		Vector3 position = Randon.insideUnitShpere * 10;
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
	    Destroy(gameObject);   
            ControllerAudio.instance.PlayOneShot(songDie);
	}
	
	void SwitchZombies(){
		randoZombie = Random.Range(1,28);
		transform.GetChild(randoZombie).gameObject.SetActive(true);
	}
}
