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
	

	// Use this for initialization
	void Start () {
		Player= GameObject.FindWithTag("Player");
		randoZombie = Random.Range(1,28);
		transform.GetChild(randoZombie).gameObject.SetActive(true);
		controllerPlayer = Player.GetComponent<ControllerPlayer>();
		animatorEnemy = GetComponent<Animator>();
		rigidbodyEnemy =  GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	void FixedUpdate()
	{
		direction = Player.transform.position - transform.position ;
		rotation =Quaternion.LookRotation(direction);
		rigidbodyEnemy.MoveRotation(rotation);
		distance = Vector3.Distance(transform.position,Player.transform.position);
		if (distance >2.5){
			animatorEnemy.SetBool("isAttack",false);
			rigidbodyEnemy.MovePosition(
				rigidbodyEnemy.position + 
				(direction.normalized * Velocity * Time.deltaTime)) ;
		}else{
			animatorEnemy.SetBool("isAttack",true);
			controllerPlayer.TextGameOver.SetActive(false);
		}
	}
	void AttackPlayer()
	{
		Time.timeScale = 0;
		controllerPlayer.TextGameOver.SetActive(true);
		controllerPlayer.life = false;
	}
}
