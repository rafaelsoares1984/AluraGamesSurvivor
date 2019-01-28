using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitMedicine : MonoBehaviour
{
    public int qtdHeal = 15;
    private int timeDestriction = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeDestriction );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider objectCollision)
    {

        if(objectCollision.tag.Equals(Tags.player)){
            objectCollision.GetComponent<ControllerPlayer>().HealLife(qtdHeal);
            Destroy(objectCollision);
        }
        
    }
}
