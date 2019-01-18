
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCha : MonoBehaviour {
  
  private Rigidbody myRigidbody;
  
  void Awake(){
    myRigidbody = GetComponent<Rigidbody>();
  }
  
  
  void Movement(Vector3 direction , float velocity)
  {
    myRigidbody.MovePosition(
				myRigidbody.position + 
				(direction.normalized * velocity * Time.deltaTime)) ;
  }

}
