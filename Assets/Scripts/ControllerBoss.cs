using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerBoss : MonoBehaviour, ITakeDamage
{
    private Transform player;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    private StatusChar stateBoss;
    private AnimationChar animatorBoss;
    private MovementChar movementBoss;
    public GameObject  kitMedicine;
    void Start()
    {
       player = GameObject.FindWithTag(Tags.player).transform;
       agent = GetComponent<NavMeshAgent>();
       stateBoss = GetComponent<StatusChar>();
       agent.speed = stateBoss.velocity;
       animatorBoss = GetComponent<AnimationChar>();
       movementBoss = GetComponent<MovementChar>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
        animatorBoss.MoveAnimator(agent.velocity);
        if (agent.hasPath){
            bool isChar = agent.remainingDistance <= agent.stoppingDistance;

            if (isChar){
                
                animatorBoss.Attack(true);
                Vector3 direction = player.position - transform.position;
                movementBoss.RotationChar(direction);
            }else{
                animatorBoss.Attack(false);
            }
        }
    }
    void AttackPlayer(){
        int damage = Random.Range(30,40);
        player.GetComponent<ControllerPlayer>().TakeDamage(damage);
    }

    public void TakeDamage(int damage){
        stateBoss.life -= damage;
        if (stateBoss.life <= 0){
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject,2);
		animatorBoss.Die();
		this.enabled = false;
		movementBoss.Die();
        agent.enabled = false;
        Instantiate(kitMedicine,transform.position,Quaternion.identity);
	  //  ControllerAudio.instance.PlayOneShot(songDie);
    }
}
