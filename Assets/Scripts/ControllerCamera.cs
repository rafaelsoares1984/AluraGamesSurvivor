using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour {

	public GameObject Player ;
	private Vector3 distance;

	// Use this for initialization
	void Start () {
		distance = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Player.transform.position + distance;
	}
}
