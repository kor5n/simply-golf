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
        GotoNext();
    }
    public void GotoNext()
    {
        SceneManager.LoadScene("lvl2");
    }
}