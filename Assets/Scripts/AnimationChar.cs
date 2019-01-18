
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChar : MonoBehaviour {
  
  private Animator myAnimator;
  
  void Awake ()
  {
    myAnimator = GetComponent<Animator>();
  }
  
  públic void Attack(bool isAttack){
    myAnimator.SetBool("isAttack",isAttack)
  }

}
