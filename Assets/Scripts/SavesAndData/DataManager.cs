using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private GameData currData;

    void Start()
    {
        GetComponent<SaveManager>().LoadBinary();
        currData = GetComponent<SaveManager>().GetGameData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
