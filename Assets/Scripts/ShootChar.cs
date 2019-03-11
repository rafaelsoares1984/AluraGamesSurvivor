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
        Debug.Log(objectColision.tag.ToString());
        Quaternion rotation = Quaternion.LookRotation(-transform.forward);
        switch (objectColision.tag)
        {
             
            case Tags.enemy:
                ControllerEnemy enemy = objectColision.GetComponent<ControllerEnemy>();
                enemy.TakeDamage(damageShot); 
                enemy.ParticleBlood(transform.position,rotation);
                break;
            case Tags.boss:
                ControllerBoss boss = objectColision.GetComponent<ControllerBoss>();
                boss.TakeDamage(damageShot); 
                boss.ParticleBlood(transform.position,rotation);

                break;
        }

        Destroy(gameObject);
    }
}
