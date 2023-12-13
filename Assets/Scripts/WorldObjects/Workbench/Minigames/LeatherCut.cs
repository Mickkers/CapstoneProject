using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LeatherCut : Minigame
{
    private bool correctLeft;
    private float score;
    private float timeLeft;

    [SerializeField] private float scoreCorrect;
    [SerializeField] private float scoreDecay;
    [SerializeField] private float gameLength;

    [SerializeField] private Image scorebar;
    [SerializeField] private Image leftArrow;
    [SerializeField] private Image rightArrow;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        correctLeft = true;
        gameActive = false;
        StartCoroutine(Countdown(3));
        timeLeft = gameLength;
    }

    // Update is called once per frame
    void Update()
    {        
        if (gameActive)
        {
            Timer();
            UpdateScore();
        }
        
    }

    private void Timer()
    {
        if (timeLeft > 0)
        {
            timerText.text = (int)timeLeft + "";
            timeLeft -= Time.deltaTime;
        }
        else if(timeLeft <= 0)
        {
            timerText.text = "Time's up!";
            gameActive = false;
            MinigameOver();
        }

        
    }

    private void UpdateScore()
    {
        score -= scoreDecay * Time.deltaTime;
        score = Mathf.Clamp(score, 0f, 100f);
        scorebar.fillAmount = score / 100;
    }

    public override void MinigameDirectional(Vector2 val)
    {
        if (!gameActive) return;
        if(correctLeft && val.x < 0)
        {
            correctLeft = false;
            score += scoreCorrect;
        }
        else if (!correctLeft && val.x > 0)
        {
            correctLeft = true;
            score += scoreCorrect;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (correctLeft)
        {
            leftArrow.color = new Color(0, 1f, 0);
            rightArrow.color = new Color(1f, 1f, 1f);
        }
        else
        {
            leftArrow.color = new Color(1f, 1f, 1f);
            rightArrow.color = new Color(0, 1f, 0);
        }
    }

    public override void MinigameOver()
    {
        WorkbenchMinigameManager wmm = FindObjectOfType(typeof(WorkbenchMinigameManager)) as WorkbenchMinigameManager;
        wmm.StageOver(score);
        Destroy(this.gameObject);
    }
}
