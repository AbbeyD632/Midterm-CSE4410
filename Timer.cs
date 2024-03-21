using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] TMP_Text timerText;
    [SerializeField] float remainingTime;
    [SerializeField] int scoreToPauseAt = 6;
    private bool isPaused = false;

    private SceneController SceneController;

    void Start(){
        SceneController = FindObjectOfType<SceneController>();
    }
   

    // Update is called once per frame
    void Update()
    {
        if(!isPaused){
             if(remainingTime > 0 ){
            remainingTime -=Time.deltaTime;
            }
            else {
            remainingTime = 0;
            timerText.color = Color.red;
            isPaused = true;
            SceneManager.LoadScene("GameOver");
            }
            
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        if(SceneController != null && SceneController.GetScore() >= scoreToPauseAt){
            isPaused = true;
        }
    }
}
