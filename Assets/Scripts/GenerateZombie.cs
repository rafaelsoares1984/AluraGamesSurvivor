using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateZombie : MonoBehaviour{

    public GameObject zombie;
    private  float countTime = 0;
    public float timeSpawnZombie = 1;
    public LayerMask zumbiLayer;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        countTime += Time.deltaTime;
        if (countcTime >= timeSpawnZombie){
            StartCoroutine(GenerateZombie());
            countTime = 0;        
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
      
	Vector3 RandonPosition(){
		Vector3 position = Randon.insideUnitShpere * 3;
		position += transform.position;
		position.y = transform.position.y;
		return position;
	}
    
}
