using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ControllerInterface : MonoBehaviour{
    // Start is called before the first frame update

    private ControllerPlayer scriptControllerPlayer;
    [Header("Life Player")]
    public Slider  sliderLifePlayer;
    public GameObject PanelGameOver;
    public Text timeToPlay;
    public Text timeToPlayMax;
    public int zombieDie;
    public float timeToPlayMaxTime = 0;
    private int qtdZombieDie;
    public Text textQtdZombieDie;
    public Text textBossShow;
    

    void Start(){
        scriptControllerPlayer = GameObject.FindWithTag(Tags.player).GetComponent<ControllerPlayer>();
        sliderLifePlayer.maxValue = scriptControllerPlayer.status.life;
        UpdateSliderLifePlayer();
        timeToPlayMaxTime = PlayerPrefs.GetFloat("timeToPlayMaxTime");
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void UpdateSliderLifePlayer (){
        sliderLifePlayer.value = scriptControllerPlayer.status.life;
    }

    public void GameOver (){
        PanelGameOver.SetActive(true);
        Time.timeScale = 0;
        int minToPlay = (int) (Time.timeSinceLevelLoad / 60) ;
        int secToPlay = (int) (Time.timeSinceLevelLoad % 60);
        timeToPlay.text = "Voce sobreviveu por "+minToPlay + ":"+secToPlay;
        UpdateScore(minToPlay,secToPlay);
    }
    public void Reload(){
		SceneManager.LoadScene(Tags.levelMain);
	}
    public void UpdateScore(int min, int sec){
        if (Time.timeSinceLevelLoad > timeToPlayMaxTime){
            timeToPlayMaxTime = Time.timeSinceLevelLoad;
            timeToPlayMax.text = string.Format("Seu melhor tempo foi {0}:{1}",min,sec);
            PlayerPrefs.SetFloat("timeToPlayMaxTime",timeToPlayMaxTime);
        }
        if (timeToPlayMax.text.Equals("")){
            int minToPlay = (int) (timeToPlayMaxTime / 60) ;
            int secToPlay = (int) (timeToPlayMaxTime % 60) ;
            timeToPlayMax.text = string.Format("Seu melhor tempo foi {0}:{1}",minToPlay,secToPlay);
        }
    }
    public void UpdateQtdZombieDie(){
        qtdZombieDie ++;
        textQtdZombieDie.text = string.Format("X {0}",qtdZombieDie);
       // PlayerPrefs.SetFloat("timeToPlayMaxTime",timeToPlayMaxTime);
    }

    public void ShowTextBoss(){
        StartCoroutine(HideText(2,textBossShow)); 
    }

    IEnumerator HideText(float timeHide,Text textHide){
        textHide.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Color colorText = textHide.color;
        colorText.a = 1;
        textHide.color = colorText;
        float cont = 0;
        while (textBossShow.color.a >0){
            cont += Time.deltaTime / timeHide;
            colorText.a = Mathf.Lerp(1,0,cont);
            textHide.color = colorText;
            if (colorText.a <= 0){
                textHide.gameObject.SetActive(false);
            }
            yield return  null;
        }
    }
}