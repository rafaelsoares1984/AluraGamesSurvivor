using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAudio : MonoBehaviour {
  
  private AudioSource myAudioSource;
  public statict AudioSource instace;
  
  voi Awake()
  {
    myAudioSource = GetComponent<AudioSource>();
    instance = myAudioSource;
  }
  
}
