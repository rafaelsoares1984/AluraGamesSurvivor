using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemy : MonoBehaviour {

	public GameObject Player;
	private Vector3 direction;
	private float distance;
	public float Velocity = 5;
	private Quaternion rotation;
	private int randoZombie;
	private ControllerPlayer controllerPlayer;
	private Animator animatorEnemy;
	private Rigidbody rigidbodyEnemy;
	pŕivate MovementChar myMovement;
	pŕivate AnimationChar myAnimationChar;
	

	// Use this for initialization
	void Start () {
		Player= GameObject.FindWithTag("Player");
		switchZombies();
		controllerPlayer = Player.GetComponent<ControllerPlayer>();
		animatorEnemy = GetComponent<Animator>();
		rigidbodyEnemy =  GetComponent<Rigidbody>();
		myMovement = GetComponent<MovementChar>();
		myAnimationChar = GetComponent<AnimationChar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	void FixedUpdate()
	{
		direction = Player.transform.position - transform.position ;
		myMovement.Rotation(direction);
		distance = Vector3.Distance(transform.position,Player.transform.position);
		if (distance >2.5){
			myAnimationChar.Attack(false);
			myMovement.Movement(direction,Velocity);
		}else{
			myAnimationChar.Attack(true);
			controllerPlayer.TextGameOver.SetActive(false);
		}
	}
	void AttackPlayer()
	{
		//Time.timeScale = 0;
		//controllerPlayer.TextGameOver.SetActive(true);
		//controllerPlayer.life = false;
		int damage = Random.Range(20, 30);
    		controllerPlayer.GetComponent<ControlaJogador>().TakeDamage(damage);
		
	}
	void switchZombies()
	{
		randoZombie = Random.Range(1,28);
		transform.GetChild(randoZombie).gameObject.SetActive(true);
	}
}
