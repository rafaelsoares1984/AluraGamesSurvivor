
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusChar : MonoBehaviour {
  [HideInInspector]
  public int life = 100;
  public float velocity = 5;
  public int initialLife = 100; 
  
  void(){
    life = initialLife;
  }
  
}
