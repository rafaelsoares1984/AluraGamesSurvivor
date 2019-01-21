
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCha : MonoBehaviour {
  
  private Rigidbody myRigidbody;
  privater Quaternion rotation;
  
  void Awake(){
    myRigidbody = GetComponent<Rigidbody>();
  }
  
  public void Movement(Vector3 direction , float velocity)
  {
    myRigidbody.MovePosition(
				myRigidbody.position + 
				(direction.normalized * velocity * Time.deltaTime)) ;
  }
	
  public void Rotation(Vector3 direction ){
	 rotation =Quaternion.LookRotation(direction);
	 myRigidbody.MoveRotation(rotation); 
  }

}
