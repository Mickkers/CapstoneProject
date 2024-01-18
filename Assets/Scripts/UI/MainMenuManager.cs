using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private RectTransform settingsUI;
    [SerializeField] private RectTransform mainButtons;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button exitGameButton;

    // Start is called before the first frame update
    void Start()
    {
        if (!saveManager.SaveExists())
        {
            continueGameButton.interactable = false;
            continueGameButton.image.color = new Color(1, 1, 1, 0.7f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSettings(bool val)
    {
        settingsUI.gameObject.SetActive(val);
        mainButtons.gameObject.SetActive(!val);
    }

    public void NewGame()
    {
        CreateNewGame();
    }

    public void CreateNewGame()
    {
        saveManager.CreateNewSave();
        SceneManager.LoadScene("Level");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
