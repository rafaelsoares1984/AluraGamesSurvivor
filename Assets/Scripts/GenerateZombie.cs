using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateZombie : MonoBehaviour{

    public GameObject zombie;
    private  float countTime = 0;
    public float timeSpawnZombie = 1;
    public LayerMask zumbiLayer;
    private float distanceGenerator= 3;
    private GameObject player;
    private float distanceGeneratorPlayer= 20;
    private Tags tag;
	

    // Start is called before the first frame update
    void Start(){
          player = GameObject.FindWithTag(tag.player);

    }

    // Update is called once per frame
    void Update(){
	if (Vector3.Distance(transform.position,player.transform.position)
	    >distanceGeneratorPlayer){
		countTime += Time.deltaTime;
		if (countcTime >= timeSpawnZombie){
		    StartCoroutine(GenerateZombie());
		    countTime = 0;        
		}
	}
    }
    
    IEnumerator RandomizePosition(){
        Vector3 posiotnCreate = RandonPosition();
        Collider[] colision = Physics.OverlapSphere(posiotnCreate,1,zumbiLayer);
        
        while (colision.Length > 0){
            posiotnCreate = RandonPosition();
            colision = Physics.OverlapSphere(posiotnCreate,1,zumbiLayer);
            yield return null;
        }
    }
    
    void OnDrawGizmos(){
	    Gizmos.color = Color.yellow;
	    Gizmos.DrawWireShpere(transform.position,distanceGenerator);
    }
	
    Vector3 RandonPosition(){
	Vector3 position = Randon.insideUnitShpere * distanceGenerator;
	position += transform.position;
	position.y = transform.position.y;
	return position;
   }
    
}
