using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerArm : MonoBehaviour
{
    public GameObject Shot;
    public GameObject CanoArma;
    public AudioClip SongShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(Shot,CanoArma.transform.position,CanoArma.transform.rotation);
            ControllerAudio.instace.PlayOneShot(SongShot);
        }
    }
}
