
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusChar : MonoBehaviour {
  //[HideInInspector]
  [Range(1, 100)]
  public int life = 100;
  [Range(1, 100)]
  public float velocity = 5;
  [Range(1, 100)]
  public int initialLife = 100; 
  
  void start(){
    life = initialLife;
  }
  
}
