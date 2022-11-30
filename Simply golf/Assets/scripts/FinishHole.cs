using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishHole : MonoBehaviour
{
    [Header("Fireworks")]
    public GameObject green;
    public GameObject blue;
    public GameObject red;
    public GameObject tadaSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            Debug.Log("player has finished!");

            GameObject fireGreen = Instantiate(green, transform.position, Quaternion.identity);
            GameObject fireRed = Instantiate(red, transform.position, Quaternion.identity);
            GameObject fireBlue = Instantiate(blue, transform.position, Quaternion.identity);
            GameObject tada = Instantiate(tadaSound, transform.position, Quaternion.identity);

            Destroy(tada, 2);
            Destroy(fireBlue, 2);
            Destroy(fireGreen, 2);
            Destroy(fireRed, 2);

            UI.hasFinished = true;
        }
    }
}
