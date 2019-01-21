using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChar : MonoBehaviour {
  
  private Animator myAnimator;
  
  void Awake (){
    myAnimator = GetComponent<Animator>();
  }
  
  public void Attack(bool isAttack){
    
	//	if (direction != Vector3.zero){
//			animatorPlayer.SetBool("isWalking",true);
	//		animatorPlayer.SetBool("isIdle",false);
		//}else{
	//		animatorPlayer.SetBool("isWalking",false);
	//		animatorPlayer.SetBool("isIdle",true);
//		}
    
    myAnimator.SetBool("isAttack",isAttack);
  }

}
