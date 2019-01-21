using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementChar : MonoBehaviour {
  
  private Rigidbody myRigidbody;
  private Quaternion rotate;
  
  void Awake(){
    myRigidbody = GetComponent<Rigidbody>();
  }
  
  public void Movement(Vector3 direction , float velocity){
    myRigidbody.MovePosition(
			myRigidbody.position + 
			(direction.normalized * velocity * Time.deltaTime)) ;
  }
	
  public void RotationChar(Vector3 direction ){
	  rotate =Quaternion.LookRotation(direction);
	  myRigidbody.MoveRotation(rotate); 
  }

}
