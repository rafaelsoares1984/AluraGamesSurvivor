using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateZombie : MonoBehaviour{

    public GameObject zombie;
    private  float countTime = 0;
    public float timeSpawnZombie = 1;
    public LayerMask zombieLayer;
    private float distanceGenerator= 3;
    private GameObject player;
    private int qtdMaxZombieGeerate = 2;
    private int qtdZombieLife;
    private float distanceGeneratorPlayer= 20;
    private float timeNextIncreaseDificult= 30;

    private float countIncreaseDificult;

    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindWithTag(Tags.player);
        countIncreaseDificult = timeNextIncreaseDificult;
        for (int i =0;i<qtdMaxZombieGeerate; i++){
            StartCoroutine( RandomizePosition());
        }
    }

    // Update is called once per frame
    void Update(){

        bool isGenerateZombieDistance = Vector3.Distance(transform.position,player.transform.position) >distanceGeneratorPlayer;
        
        if (isGenerateZombieDistance && qtdZombieLife < qtdMaxZombieGeerate){
            countTime += Time.deltaTime;
            if (countTime >= timeSpawnZombie){
                StartCoroutine( RandomizePosition());
                countTime = 0;        
            }
        }
        if (Time.timeSinceLevelLoad>countIncreaseDificult){
            qtdMaxZombieGeerate ++;
            countIncreaseDificult = Time.timeSinceLevelLoad + timeNextIncreaseDificult;
        }
    }
    
    IEnumerator RandomizePosition(){
        Vector3 posiotnCreate = RandonPosition();
        Collider[] colision = Physics.OverlapSphere(posiotnCreate,1,zombieLayer);
        
        while (colision.Length > 0){
            posiotnCreate = RandonPosition();
            colision = Physics.OverlapSphere(posiotnCreate,1,zombieLayer);
            yield return null;
        }
        ControllerEnemy zombieGenerate = Instantiate(zombie, posiotnCreate, transform.rotation).GetComponent<ControllerEnemy>();
        zombieGenerate.myGenerator = this; 
        qtdZombieLife ++;
    }
  //  [ExecuteInEditMode]
    void OnDrawGizmos(){
	    Gizmos.color = Color.yellow;
	    Gizmos.DrawWireSphere(transform.position,distanceGenerator);
    }
	
    Vector3 RandonPosition(){
	Vector3 position =  Random.insideUnitSphere * distanceGenerator;
	position += transform.position;
	position.y = transform.position.y;
	return position;
   }
    
    public void DecreaseZombieLife(){
        qtdZombieLife --;
    }
}
