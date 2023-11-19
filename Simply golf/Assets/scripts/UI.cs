using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static bool hasFinished;
    [Header("UI components")]
    public Slider powerBar;
    public Text scoreText;
    public GameObject FinishPanel;
    public Button BackArrow;
    [Header("FinishPanel components")]
    public Text FinishText;

    // Start is called before the first frame update
    private void Start()
    {
        powerBar.maxValue = Player.maxSpeed;
        powerBar.minValue = Player.minSpeed;
        FinishPanel.SetActive(false);
        hasFinished = false;
        BackArrow.onClick.AddListener(BackToMainMenu);
    }
    private void Update()
    {
        powerBarSpeed();
        ScoreChange();
        
        ShowFinishPanel();
    }
    void powerBarSpeed()
    {
        Player.speed = powerBar.value;// controlling the players speed
        Debug.Log(Player.speed);
    }
    void ScoreChange()
    {
        scoreText.text = Player.score.ToString();
    }
    void ShowFinishPanel()
    {
        if(hasFinished)
        {
            FinishPanel.SetActive(true);
        }
    }
    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
        


}