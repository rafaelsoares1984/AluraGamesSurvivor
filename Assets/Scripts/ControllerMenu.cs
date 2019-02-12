using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{
    public GameObject exit;
    // Start is called before the first frame update
    void Start()
    {
       #if UNITY_STANDALONE || UNITY_EDITOR
            exit.SetActive(true);
       #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame(){
        StartCoroutine(ChanceScene(Tags.levelMain));
    }

    IEnumerator ChanceScene(string scene){
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(scene);
    }

    public void ExitGame(){
        StartCoroutine(QuitScene());
    }
    
    IEnumerator QuitScene(){
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif    
    }
}
