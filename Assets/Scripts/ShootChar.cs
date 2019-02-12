using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootChar : MonoBehaviour{
    
    public float velocity = 20;
    private Rigidbody rigidbodyShot;
    public AudioClip songDie;
    private int damageShot = 1;

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
        
        switch (objectColision.tag)
        {
            case Tags.enemy:
                objectColision.GetComponent<ControllerEnemy>().TakeDamage(damageShot); 
                break;
            case Tags.boss:
                objectColision.GetComponent<ControllerBoss>().TakeDamage(damageShot);
                break;
        }

        Destroy(gameObject);
    }
}
