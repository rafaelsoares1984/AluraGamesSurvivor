﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerPlayer : MonoBehaviour {

	// Use this for initialization
	private Vector3 direction;
	private Quaternion newRotation;
	public LayerMask floorMask;
	public GameObject textGameOver;
	public bool isLife = true;
	private Rigidbody rigidbodyPlayer;
	private Animator animatorPlayer;
	public ControllerInterface scriptControllerInterface;
	public AudioClip songDamage;
	public StatusChar status;
	private MovementPlayer movement;
	private AnimationChar animator;
	
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	void Start(){
		Time.timeScale = 1;
		rigidbodyPlayer = GetComponent<Rigidbody>();
		animatorPlayer = GetComponent<Animator>();
		status = GetComponent<StatusChar>();
		movement = GetComponent<MovementPlayer>();
		animator = GetComponent<AnimationChar>();
	}

	// Update is called once per frame
	void Update () {
		float  axisX = Input.GetAxis("Horizontal");
		float  axisZ = Input.GetAxis("Vertical");
		direction = new Vector3(axisX,0,axisZ);
		
		animator.Attack(direction);
		animator.MoveAnimator(direction);
		
		if (isLife.Equals(false)){
			if (Input.GetButtonDown("Fire1")){
				SceneManager.LoadScene("Level1");
			}
		}
		
	}

	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	void FixedUpdate(){
		movement.Movement(direction,status.velocity)
		movement.RotationPlayer(floorMask);

	}
	
	public void TakeDamage(int damage){
		status.life -=damage;
		scriptControllerInterface.UpdateSliderLifePlayer();
		ControllerAudio.instance.PlayOneShot(songDamage);
		if (status.life <=0){
			Time.timeScale = 0;
			textGameOver.SetActive(true);
		}
	}
	
	void AttackPlayer(){
		Time.timeScale = 0;
		textGameOver.SetActive(true);
		isLife = false;
	}
}
