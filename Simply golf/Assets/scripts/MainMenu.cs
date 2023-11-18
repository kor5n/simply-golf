using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
   [Header("MainMenu")]
    public GameObject mainMenu;
    public Button PLAY;
    public Button LEVELS;

    [Header("Levels")]
    public GameObject levels;
    private bool pickLevel = false;
    public Button lvl1;
    public Button lvl2;
    public Button lvl3;
    // Start is called before the first frame update
    void Start()
    {
        pickLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        PLAY.onClick.AddListener(Play);
        LEVELS.onClick.AddListener(Levels);
        if (pickLevel)
        {
            lvl1.onClick.AddListener(Play);
            lvl2.onClick.AddListener(Level2);
            lvl3.onClick.AddListener(Level3);
        }
    }
    void Play()
    {
        SceneManager.LoadScene("lvl1");
    }
    void Levels()
    {
        mainMenu.SetActive(false);
        levels.SetActive(true);
        pickLevel = true;
    }
    void Level2()
    {
        SceneManager.LoadScene("lvl2");

    }
    void Level3()
    {
        SceneManager.LoadScene("lvl3");
    }
    
}
