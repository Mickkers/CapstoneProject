using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public GameData gameData;
    private string Path => Application.persistentDataPath + "/save.dat";

    private void Start()
    {
        Debug.Log(Path);
        if (SaveManager.Instance is null)
        {
            return;
        }

        if (File.Exists(Path))
        {
            LoadBinary();
        }
        else
        {
            gameData = new GameData();
            SaveBinary();
        }
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

    public void SetGameData(GameData newGameData)
    {
        gameData = newGameData;
    }

    public GameData GetGameData()
    {
        return gameData;
    }

    public bool SaveExists()
    {
        if (gameData.days > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CreateNewSave()
    {
        gameData = new GameData();
        SaveBinary();
    }

    public void SaveBinary()
    {
        FileStream file = File.OpenWrite(Path);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(file, gameData);
        file.Close();
    }

    public void LoadBinary()
    {
        FileStream file = File.OpenRead(Path);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        gameData = (GameData)binaryFormatter.Deserialize(file);
        file.Close();
    }
}
[Serializable]
public class GameData
{
    public int days;
    public int money;
    public int wood;
    public int leather;

    public int axeLevel;
    public int scytheLevel;
    public int swordLevel;

    public List<Wayang> wayangInventory;

    public GameData()
    {
        days = 0;
        money = 0;
        wood = 0;
        leather = 0;

        axeLevel = 1;
        scytheLevel = 1;
        swordLevel = 1;

        wayangInventory = new List<Wayang>();
    }
}

[Serializable]
public class Wayang
{
    public int score;
    public int type;

    public Wayang()
    {
        score = 0;
        type = 0;
    }
}
