using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerInterface : MonoBehaviour{
    // Start is called before the first frame update

    private ControllerPlayer scriptControllerPlayer;
    public Slider  sliderLifePlayer;

    void Start(){
        scriptControllerPlayer = GameObject.FindWithTag("Player").GetComponent<ControllerPlayer>();
        sliderLifePlayer.maxValue = scriptControllerPlayer.lifePlayer;
        UpdateSliderLifePlayer();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void UpdateSliderLifePlayer (){
        sliderLifePlayer.value = scriptControllerPlayer.lifePlayer;
    }

}
