using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerArm : MonoBehaviour{

    public GameObject shot;
    public GameObject pipeArm;
    public AudioClip  songShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(shot,pipeArm.transform.position,pipeArm.transform.rotation);
            ControllerAudio.instance.PlayOneShot(songShot);
        }
    }
}
