using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateZombie : MonoBehaviour
{
    public GameObject Zombie;
    private  float countTime = 0;
    public float TimeSpawnZombie = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (countTime >= TimeSpawnZombie){
            Instantiate(Zombie,transform.position, transform.rotation);
            countTime = 0;        
        }
    }
}
