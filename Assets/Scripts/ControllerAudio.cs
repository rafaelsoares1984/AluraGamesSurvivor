using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAudio : MonoBehaviour {
  
  private AudioSource myAudioSource;
  public static AudioSource instance;
  
  void Awake(){
    myAudioSource = GetComponent<AudioSource>();
    instance = myAudioSource;
  }
  
}
