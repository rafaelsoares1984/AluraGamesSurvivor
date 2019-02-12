using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ControllerBoss : MonoBehaviour, ITakeDamage
{
    private Transform player;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    private StatusChar stateBoss;
    private AnimationChar animatorBoss;
    private MovementChar movementBoss;
    public GameObject  kitMedicine;
    public Slider lifeBoss;
    public Image imageSlider;
    public Color colorLifeMax,colorLifeMin;
    void Start()
    {
       player = GameObject.FindWithTag(Tags.player).transform;
       agent = GetComponent<NavMeshAgent>();
       stateBoss = GetComponent<StatusChar>();
       agent.speed = stateBoss.velocity;
       animatorBoss = GetComponent<AnimationChar>();
       movementBoss = GetComponent<MovementChar>();
       lifeBoss.maxValue = stateBoss.initialLife;
       UpdateInterface();

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
        UpdateInterface();
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

    void UpdateInterface(){
        lifeBoss.value = stateBoss.life;
        float percentLife =  (float) stateBoss.life / stateBoss.initialLife;
        Color corLife = Color.Lerp(colorLifeMin,colorLifeMax,percentLife);
        imageSlider.color = corLife;
    }
}
