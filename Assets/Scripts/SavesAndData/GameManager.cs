using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField ]private GameData currData;
    private int currentTime;
    private int currMin;
    private int currHour;
    private int currDate;
    private int currMonth;

    // Start is called before the first frame update
    void Start()
    {
        if (SaveManager.Instance is null)
        {
            return;
        }

        currData = FindObjectOfType<SaveManager>().GetGameData();
        currDate = currData.days % 28;
        currMonth = (int)Mathf.Ceil((float)currData.days / 28);
        currentTime = 36;
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

    private void EndDay()
    {

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
        return currHour.ToString() + " : " + currMin.ToString();
    }

    public int GetMoney()
    {
        return currData.money;
    }

    public void SetMoney(int value)
    {
        currData.money += value;
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
}
