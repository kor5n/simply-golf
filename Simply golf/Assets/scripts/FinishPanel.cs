using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishPanel : MonoBehaviour
{
    [Header("Components")]
    public Text finishText;
    public Button nextBTN;
    public Button menuBTN;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finishText.text = "Level #"+ SceneManager.GetActiveScene().name[SceneManager.GetActiveScene().name.Length - 1]+" completed!";
    }
    public void GotoNext()
    {
        int lvl = int.Parse(SceneManager.GetActiveScene().name[^1..]);
        Debug.Log(lvl + 1);
        int nextLvl = lvl + 1;
        Player.score = 0;
        SceneManager.LoadScene("lvl" + nextLvl);
        
    }
    public void MainMenu()
    {
        Player.score = 0;
        SceneManager.LoadScene(0);
    }
}
