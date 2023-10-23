using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public GameData gameData;
    private string Path => Application.persistentDataPath + "/save.dat";

    private void Start()
    {
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

    public GameData()
    {
        days = 0;
        money = 0;
    }
}
