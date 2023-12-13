using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coloring : Minigame
{
    private bool correctDown;
    private float score;
    private float timeLeft;

    [SerializeField] private float scoreCorrect;
    [SerializeField] private float scoreDecay;
    [SerializeField] private float gameLength;

    [SerializeField] private Image scorebar;
    [SerializeField] private Image upArrow;
    [SerializeField] private Image downArrow;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        correctDown = true;
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
        else if (timeLeft <= 0)
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
        if (correctDown && val.y < 0)
        {
            correctDown = false;
            score += scoreCorrect;
        }
        else if (!correctDown && val.y > 0)
        {
            correctDown = true;
            score += scoreCorrect;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (correctDown)
        {
            upArrow.color = new Color(0, 1f, 0);
            downArrow.color = new Color(1f, 1f, 1f);
        }
        else
        {
            upArrow.color = new Color(1f, 1f, 1f);
            downArrow.color = new Color(0, 1f, 0);
        }
    }

    public override void MinigameOver()
    {
        WorkbenchMinigameManager wmm = FindObjectOfType(typeof(WorkbenchMinigameManager)) as WorkbenchMinigameManager;
        wmm.StageOver(score);
        Destroy(this.gameObject);
    }
}
