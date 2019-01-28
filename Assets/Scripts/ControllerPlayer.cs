using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour, ITakeDamage, IHealer {

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
		animator =   GetComponent<AnimationChar>();
		status = GetComponent<StatusChar>();

	}

	// Update is called once per frame
	void Update () {
		float  axisX = Input.GetAxis(Tags.directionHorizontal);
		float  axisZ = Input.GetAxis(Tags.directionVertical);
		direction = new Vector3(axisX, 0, axisZ);
		
		animator.MoveAnimator(direction);
		
	}

	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	void FixedUpdate(){
		movement.Movement(direction,status.velocity);
		movement.RotationPlayer(floorMask);

	}
	
	public void TakeDamage(int damage){
		status.life -=damage;
		scriptControllerInterface.UpdateSliderLifePlayer();
		ControllerAudio.instance.PlayOneShot(songDamage);
		if (status.life <=0){
			Die();
		}
	}
	
	public void Die(){
		scriptControllerInterface.GameOver();
	}
	
	public void HealLife(int qtdLife){
		status.life +=qtdLife; 
		if (status.life > status.initialLife){
			status.life = status.initialLife;
		}
		
		scriptControllerInterface.UpdateSliderLifePlayer();
	}
}
