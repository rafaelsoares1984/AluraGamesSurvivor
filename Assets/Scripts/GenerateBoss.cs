using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoss : MonoBehaviour
{
    private float timeNextGeneration = 0; 
    public float timeBetweeGeneration = 60; 
    public GameObject boss;
    private ControllerInterface scriptInterface;
    public Transform[] positionGenerateBoss;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
          timeNextGeneration = timeBetweeGeneration;
          scriptInterface = GameObject.FindObjectOfType(typeof(ControllerInterface)) as ControllerInterface;
          player = GameObject.FindWithTag(Tags.player).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > timeNextGeneration){
            Vector3 positionBoss = CalculatePositionBoss();
            Instantiate(boss,positionBoss,Quaternion.identity);
            scriptInterface.ShowTextBoss();
            timeNextGeneration = Time.timeSinceLevelLoad + timeBetweeGeneration;

        }
    }

    Vector3 CalculatePositionBoss(){
        Vector3 positionDistancePlayer = Vector3.zero; 
        float maxDistancePlayer = 0;
        foreach(Transform position in positionGenerateBoss){
            float distancePlayer = Vector3.Distance(position.position,player.position);
            if (distancePlayer> maxDistancePlayer){
                maxDistancePlayer = distancePlayer;
                positionDistancePlayer = position.position;
            }
        }
        return positionDistancePlayer;
    }
}
