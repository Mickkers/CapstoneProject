using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    DataManager dataManager;
    // Start is called before the first frame update
    void Start()
    {
        dataManager = GetComponent<DataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {

    }

    public void LoadGame()
    {
        if (!dataManager.SaveExists())
        {
            return;
        }
        SceneManager.LoadScene("TestLevel");
    }
}
