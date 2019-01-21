using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemy : MonoBehaviour {

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
		distance = Vector3.Distance(transform.position,player.transform.position);
		if (distance >2.5){
			myAnimationChar.Attack(false);
			myMovement.Movement(direction,status.velocity);
		}else{
			myAnimationChar.Attack(true);
			controllerPlayer.textGameOver.SetActive(false);
		}
	}
	
	void AttackPlayer(){
		//Time.timeScale = 0;
		//controllerPlayer.TextGameOver.SetActive(true);
		//controllerPlayer.life = false;
		int damage = Random.Range(20, 30);
    		controllerPlayer.GetComponent<ControllerPlayer>().TakeDamage(damage);
		
	}

	void SwitchZombies(){
		randoZombie = Random.Range(1,28);
		transform.GetChild(randoZombie).gameObject.SetActive(true);
	}
}
