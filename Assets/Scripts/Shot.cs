using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour{
    
    public float velocity = 20;
    private Rigidbody rigidbodyShot;
    public AudioClip songDie;

    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    void Start(){
        rigidbodyShot = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate(){
       rigidbodyShot.MovePosition(
           rigidbodyShot.position + transform.forward * velocity * Time.deltaTime) ;
    }

    // OnTriggerEnter is called when the Collider other enters the trigger.
    void OnTriggerEnter(Collider objectColision){
        if (objectColision.tag.Equals("Inimigo")){
            Destroy(objectColision.gameObject);   
            ControllerAudio.instance.PlayOneShot(songDie);
        }
        Destroy(gameObject);
    }
}
