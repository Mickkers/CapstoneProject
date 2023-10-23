using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] SaveManager saveManager;
    [SerializeField] Button newGameButton;
    [SerializeField] Button continueGameButton;
    [SerializeField] Button exitGameButton;

    [SerializeField] Button exitButton;
    [SerializeField] Button confirmButton;
    [SerializeField] RectTransform confirmationPrompt;

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

    public void NewGame()
    {
        if (saveManager.SaveExists())
        {
            //prompt save overwrite
            PromptOverwrite();
        }
        else
        {
            //create new save
            CreateNewGame();
        }
    }

    private void PromptOverwrite()
    {
        confirmationPrompt.gameObject.SetActive(true);
        confirmButton.gameObject.SetActive(true);
    }

    public void CreateNewGame()
    {
        saveManager.CreateNewSave();
        SceneManager.LoadScene("TestLevel");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("TestLevel");
    }

    public void ExitGame()
    {
        PromptExit();
    }

    private void PromptExit()
    {
        confirmationPrompt.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void ConfirmExit()
    {
        Application.Quit();
    }

    public void ConfirmReturn()
    {
        confirmationPrompt.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(false);
    }
}
