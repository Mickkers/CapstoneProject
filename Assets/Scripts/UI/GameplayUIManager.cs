using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameplayUIManager : MonoBehaviour
{
    [SerializeField] private RectTransform pauseUI;
    [SerializeField] private RectTransform gameplayUI;
    [SerializeField] private TMP_Text monthDate;
    [SerializeField] private TMP_Text time;
    [SerializeField] private TMP_Text resources;

    private GameManager gameManager;
    private GameplayInputManager gameplayInput;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameplayInput = FindAnyObjectByType<GameplayInputManager>();
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        monthDate.text = gameManager.GetDate().ToString();
        time.text = gameManager.GetTime();
        resources.text = "Money: \n" + gameManager.GetMoney() + "\nWood: \n" + gameManager.GetWood() + "\nLeather: \n" + gameManager.GetLeather();
    }

    public void TogglePause(bool Val)
    {
        pauseUI.gameObject.SetActive(Val);
        gameplayUI.gameObject.SetActive(!Val);
        if (Val)
        {
            gameplayInput.enabled = false;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            gameplayInput.enabled = true;
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
