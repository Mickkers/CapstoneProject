using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Minigame : MonoBehaviour
{
    public bool gameActive;
    public TextMeshProUGUI timerText;

    public IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            timerText.text = "" + count;
            yield return new WaitForSeconds(1);
            count--;
        }

        timerText.text = "Start!";
        gameActive = true;

        yield return new WaitForSeconds(.5f);
        timerText.text = "";
    }

    public abstract void MinigameDirectional(Vector2 val);
    public abstract void MinigameOver();
}
