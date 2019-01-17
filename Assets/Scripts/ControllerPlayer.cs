using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerPlayer : MonoBehaviour {

	// Use this for initialization
	public float Velocity = 10;
	private Vector3 direction;
	private RaycastHit impact;
	private Quaternion newRotation;
	private Ray raio;
	private Vector3 positionTarget;
	public LayerMask FloorMask;
	public GameObject TextGameOver;
	public bool life = true;
	private Rigidbody rigidbodyPlayer;
	private Animator animatorPlayer;
	public int lifePlayer = 100;

	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.

	void Start()
	{
		Time.timeScale = 1;
		rigidbodyPlayer = GetComponent<Rigidbody>();
		animatorPlayer = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		float  axisX = Input.GetAxis("Horizontal");
		float  axisZ = Input.GetAxis("Vertical");
		direction = new Vector3(axisX,0,axisZ);

		//transform.Translate(direction * velocity * Time.deltaTime );

		if (direction != Vector3.zero){
			animatorPlayer.SetBool("isWalking",true);
			animatorPlayer.SetBool("isIdle",false);
		}	else{
			animatorPlayer.SetBool("isWalking",false);
			animatorPlayer.SetBool("isIdle",true);
		}

		if (life.Equals(false)){
			if (Input.GetButtonDown("Fire1")){
				SceneManager.LoadScene("Level1");
			}
		}
	}

	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	void FixedUpdate()
	{
		rigidbodyPlayer.MovePosition(
			rigidbodyPlayer.position+
			(direction * Velocity * Time.deltaTime));
		raio = Camera.main.ScreenPointToRay(Input.mousePosition);
		//Debug.DrawRay(raio.origin,raio.direction,Color.red);
		if (Physics.Raycast(raio,out impact,100,FloorMask)){
			positionTarget = impact.point - transform.position;
			positionTarget.y = transform.position.y;
			newRotation = Quaternion.LookRotation(positionTarget);
			rigidbodyPlayer.MoveRotation(newRotation);
		}
	} 
}
