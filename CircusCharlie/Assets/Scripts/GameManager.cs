using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController playerController;

    public TMP_Text stageScoreText;
    public TMP_Text totalScoreText;
    public TMP_Text bonusScoreText;
    public TMP_Text stageNumberText;
    public GameObject playerLife1;
    public GameObject playerLife2;
    public GameObject playerLife3;
    public GameObject playerLife4;

    public GameObject StageUI;
    public GameObject gameoverUI;

    public int stageNumber = 1;
    public int stageScore = 0;
    private int totalScore = 0;
    private int bonusScore = 5000;
    private float bonusTimer;
    public int life = 4;

    public bool isGameover = false;
    public bool isStageClear = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBonus();
        UpdateScore();
    }








    public void UpdateBonus() 
    {
        int bonusSetTimer = (int)1f;
        bonusTimer += Time.deltaTime;

        if (bonusScore > 0 && bonusTimer >= bonusSetTimer)
        {
            bonusScore -= 10;
            bonusTimer = 0f;
        }
        else if (bonusScore == 0)
        {
            bonusScore = 0;
        }
    }


    public void UpdateScore() 
    {
        if (isGameover == false)
        {
            stageScoreText.text = string.Format($"Sc={stageScore}");
            bonusScoreText.text = string.Format($"BONUS={bonusScore}");
            totalScoreText.text = string.Format($"To={totalScore}");
        }
        else if (isGameover == true || isStageClear == true)
        {
            totalScore = stageScore + bonusScore;
            stageScoreText.text = string.Format($"Sc={stageScore}");
            bonusScoreText.text = string.Format($"BONUS={bonusScore}");
            totalScoreText.text = string.Format($"To={totalScore}");
        }
    }




    public void DieOnce() 
    {
        if (life == 4)
        {
            playerLife1.SetActive(false);
            life -= 1;
            PlayStage();
        }
        else if (life == 3)
        {
            playerLife2.SetActive(false);
            life -= 1;
            PlayStage();
        }
        else if (life == 2)
        {
            playerLife3.SetActive(false);
            life -= 1;
            PlayStage();
        }
        else if (life == 1)
        {
            playerLife4.SetActive(false);
            life -= 1;
            PlayStage();
        }
        else if (life == 0)
        {
            GameOver();
        }
    }

    public void PlayStage()
    {
        StageUI.SetActive(true);
        playerController.playerAnimator.ResetTrigger("Die");
        //    bigHoop.SetActive(true);
        //    smallHoop.SetActive(true);
        //    pot.SetActive(true);
        //    respawner.SetActive(true);



        if (Input.GetButtonDown("Jump")) 
        {
            Time.timeScale = 1;
            StageUI.SetActive(false);

        //    bigHoop.SetActive(true);
        //    smallHoop.SetActive(true);
        //    pot.SetActive(true);
        //    respawner.SetActive(true);
           
        }
    }

    public void GameOver() 
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }

}
