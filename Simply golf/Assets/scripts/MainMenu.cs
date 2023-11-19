using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [Header("BackButton")]
    public GameObject BackButtonObj;
    public Button BackButton;

    [Header("MainMenu")]
    public GameObject mainMenu;
    public Button PLAY;
    public Button LEVELS;
    public Button SETTINGS;

    [Header("Levels")]
    public GameObject levels;
    public Button lvl1;
    public Button lvl2;
    public Button lvl3;

    [Header("Settings")]
    private bool settingsOn;
    public GameObject settings;
    public Slider Sensetivity;
    public Text SensetivityText;
    // Start is called before the first frame update
    void Start()
    {
        settingsOn = false;
        BackButtonObj.SetActive(false);
        PLAY.onClick.AddListener(Play);
        LEVELS.onClick.AddListener(Levels);
        SETTINGS.onClick.AddListener(GotoSettings);
        BackButton.onClick.AddListener(LoadMenu);
        lvl1.onClick.AddListener(Play);
        lvl2.onClick.AddListener(Level2);
        lvl3.onClick.AddListener(Level3);
    }

    // Update is called once per frame
    void Update()
    {
        if (settingsOn)
        {
            SensetivityText.text = "Sensetivity: " + Sensetivity.value.ToString();
            CameraPivot.sensetivity = Sensetivity.value;
        }
    }
    private void GotoSettings()
    {
        Sensetivity.maxValue = 50f;
        Sensetivity.minValue = 1f;
        if(CameraPivot.sensetivity >=1)
        {
            Sensetivity.value = CameraPivot.sensetivity;
        }
        BackButtonObj.SetActive(true);
        mainMenu.SetActive(false);
        settings.SetActive(true);
        settingsOn = true;
    }

    void Play()
    {
        SceneManager.LoadScene("lvl1");
    }
    void Levels()
    {
        BackButtonObj.SetActive(true);
        mainMenu.SetActive(false);
        levels.SetActive(true);
    }
    void Level2()
    {
        SceneManager.LoadScene("lvl2");

    }
    void Level3()
    {
        SceneManager.LoadScene("lvl3");
    }
    private void LoadMenu()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
        levels.SetActive(false);
        settingsOn = false;
        BackButtonObj.SetActive(false);
    }
    void CahngeSensetivity()
    {

    }


    
}
