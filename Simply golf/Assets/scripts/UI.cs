using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider powerBar;
    public Text scoreText;
    // Start is called before the first frame update
    private void Start()
    {
        powerBar.maxValue = Player.maxSpeed;
        powerBar.minValue = Player.minSpeed;
    }
    private void Update()
    {
        powerBarSpeed();
        ScoreChange();
    }
    void powerBarSpeed()
    {
        Player.speed = powerBar.value;
    }
    void ScoreChange()
    {
        scoreText.text = Player.score.ToString();
    }
    
}