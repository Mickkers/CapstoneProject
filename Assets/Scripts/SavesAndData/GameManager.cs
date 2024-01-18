using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameData currData;
    private SaveManager saveManager;
    private int currentTime;
    private int currMin;
    private int currHour;
    private int currDate;
    private int currMonth;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance is null)
        {
            return;
        }
        saveManager = FindObjectOfType<SaveManager>();
        currData = saveManager.GetGameData();
        if(currData.days == 0)
        {
            currData.days++;
        }
        currDate = currData.days % 28;
        currMonth = (int)Mathf.Ceil((float)currData.days / 28);
        currentTime = 36;
        currHour = (int)Mathf.Floor((float)currentTime / 6);
        currMin = ((currentTime % 6) * 10);
        StartCoroutine(IncrementTime());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator NextDay()
    {
        currData.days++;
        saveManager.SetGameData(currData);
        saveManager.SaveBinary();

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneStrings.Level);
        Destroy(this.gameObject);
    }

    private IEnumerator IncrementTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(7);
            currentTime++;
            if(currentTime == 145)
            {
                currentTime = 0;
            }
            else
            {
                currHour = (int)Mathf.Floor((float)currentTime / 6);
                currMin = ((currentTime % 6) * 10);
            }
        }
    }

    public void Gameover()
    {
        SetMoney(-500);
        NextDay();

    }

    public int GetMonth()
    {
        return currMonth;
    }

    public int GetDate()
    {
        return currDate;
    }

    public string GetTime()
    {
        string hour;
        string minute;
        if(currHour < 10)
        {
            hour = "0" + currHour;
        }
        else
        {
            hour = currHour.ToString();
        }
        if(currMin == 0)
        {
            minute = "0" + currMin;
        }
        else
        {
            minute = currMin.ToString();
        }

        return "<mspace=30>" + hour + " " + minute + "</mspace>";
        //return currHour.ToString() + " : " + currMin.ToString();
    }

    public int GetMoney()
    {
        return currData.money;
    }

    public void SetMoney(int value)
    {
        currData.money += value;
        currData.money = Mathf.Clamp(currData.money, 0, int.MaxValue);
    }

    public int GetLeather()
    {
        return currData.leather;
    }

    public void SetLeather(int value)
    {
        currData.leather += value;
    }

    public int GetWood()
    {
        return currData.wood;
    }

    public void SetWood(int value)
    {
        currData.wood += value;
    }

    public bool IsInventoryEmpty()
    {
        if (currData.wayangInventory.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetWayangValue()
    {
        int value = 0;
        Wayang[] wayangs = currData.wayangInventory.ToArray();
        foreach (Wayang wayang in wayangs)
        {
            value += wayang.score;
        }
        return value;
    }

    public int[] GetUpgradeLevels()
    {
        int[] levels = { currData.sellMultiplierLevel, currData.axeLevel, currData.swordLevel };
        return levels;
    }
}
